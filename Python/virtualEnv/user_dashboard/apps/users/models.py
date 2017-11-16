# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models
import re
import bcrypt

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

class UserManager(models.Manager):
    def validLog(self, postData):
        errors = []
        if len(self.filter(email=postData['email'])) > 0:
            user = self.filter(email=postData['email'])[0]
            if not bcrypt.checkpw(postData['password'].encode(), user.password.encode()):
                errors.append("Email and password must match.")
        else:
            errors.append("Email not in the system")

        if errors:
            return errors
        return user

    def validReg(self, postData):
        errors = []
        if len(postData['first_name']) < 2 or len(postData['last_name']) < 2:
            errors.append("Name fields must be at least 3 characters.")
        if any(char.isdigit() for char in postData['first_name']) or any(char.isdigit() for char in postData['last_name']):
            errors.append("Name fields cannot contain numbers.")
        if not EMAIL_REGEX.match(postData['email']):
            errors.append("Email format not valid.")
        if len(postData['password']) < 8:
            errors.append("Password must be at least 8 characters.")
        if postData['password'] != postData['confirm_password']:
            errors.append("Passwords must match")
        if not errors:
            hashedPassword = bcrypt.hashpw((postData['password'].encode()), bcrypt.gensalt(5))
            newUser = self.create(
                first_name = postData['first_name'],
                last_name = postData['last_name'],
                email = postData['email'],
                password = hashedPassword
            )
            return newUser
        return errors

    def admin_add(self, postData):
        errors = []
        if len(postData['first_name']) < 2 or len(postData['last_name']) < 2:
            errors.append("Name fields must be at least 3 characters.")
        if any(char.isdigit() for char in postData['first_name']) or any(char.isdigit() for char in postData['last_name']):
            errors.append("Name fields cannot contain numbers.")
        if not EMAIL_REGEX.match(postData['email']):
            errors.append("Email format not valid.")
        if len(postData['password']) < 8:
            errors.append("Password must be at least 8 characters.")
        if postData['password'] != postData['confirm_password']:
            errors.append("Passwords must match")
        if len(postData['admin_level']) < 1:
            errors.append('Admin level cannot be left blank.')
        
        if not errors:
            hashedPassword = bcrypt.hashpw((postData['password'].encode()), bcrypt.gensalt(5))
            newUser = self.create(
                first_name = postData['first_name'],
                last_name = postData['last_name'],
                email = postData['email'],
                password = hashedPassword,
                admin_level = postData['admin_level']
            )
            return newUser
        return errors

    def validInfo(self, postData):
        errors = []
        if len(postData['first_name']) < 2 or len(postData['last_name']) < 2:
            errors.append("Name fields must be at least 3 characters.")
        if any(char.isdigit() for char in postData['first_name']) or any(char.isdigit() for char in postData['last_name']):
            errors.append("Name fields cannot contain numbers.")
        if not EMAIL_REGEX.match(postData['email']):
            errors.append("Email format not valid.")
        if len(postData['password']) < 8:
            errors.append("Password must be at least 8 characters.")
        if postData['password'] != postData['confirm_password']:
            errors.append("Passwords must match")

        return errors

class User(models.Model):
    first_name = models.CharField(max_length = 255)
    last_name = models.CharField(max_length = 255)
    email = models.CharField(max_length = 255, unique = True)
    password = models.CharField(max_length = 255)
    admin_level = models.CharField(max_length = 10)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = UserManager()

class Message(models.Model):
    content = models.TextField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    poster = models.ForeignKey(User, related_name = "messages")
    posted_on = models.IntegerField(default = 0)

class Response(models.Model):
    content = models.TextField()
    message = models.ForeignKey(Message, related_name = "responses")
    responder = models.ForeignKey(User, related_name = "responses_left")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    