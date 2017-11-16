# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from ..users.models import User
from django.db import models

# Create your models here.
class Book(models.Model):
    title = models.CharField(max_length = 255)
    author = models.CharField(max_length = 255)
    user = models.ForeignKey(User, related_name = "books")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

class Review(models.Model):
    content = models.TextField(default = "some_string")
    rating = models.IntegerField()
    book = models.ForeignKey(Book, related_name = "reviews")
    reviewer = models.ForeignKey(User, related_name = "reviews_left")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)