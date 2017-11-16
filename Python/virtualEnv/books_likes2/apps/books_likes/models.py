# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

class Book(models.Model):
    name = models.CharField(max_length=255)
    desc = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    uploader = models.ForeignKey(User, related_name="uploaded_books")
    likes = models.ManyToManyField(User, related_name="liked_books")

# Create 3 different user accounts
    # User.objects.create(first_name="Steven", last_name="Universe", email="gemboy@gmail.com")
    # User.objects.create(first_name="Greg", last_name="Universe", email="rockerdad@gmail.com")
    # User.objects.create(first_name="Rose", last_name="Quartz", email="giantwoman@gmail.com")

# Have the first user create 2 books.
    # Book.objects.create(name="Guitar Lessons", desc="How to write great beach songs", uploader=User.objects.get(id=1))
    # Book.objects.create(name="Watermelon Parenting", desc="How to care for your watermelon clones", uploader=User.objects.get(id=1))

# Have the second user create 2 other books.
    # Book.objects.create(name="So Your Wife Is a Big Rock Alien", desc="Dealing with interspecies relationships", uploader=User.objects.get(id=2))
    # Book.objects.create(name="Car Washing 101", desc="Owning a mediocre car wash", uploader=User.objects.get(id=2))

# Have the third user create 2 other books.
    # Book.objects.create(name="Gem History", desc="Just the last 6000 years", uploader=User.objects.get(id=3))
    # Book.objects.create(name="Gregnant???", desc="Human anatomy is weird", uploader=User.objects.get(id=3))

# Have the first user like the last book and the first book
    # User.objects.get(id=1).liked_books.add(Book.objects.first())
    # User.objects.get(id=1).liked_books.add(Book.objects.last())

# Have the second user like the first book and the third book
    # User.objects.get(id=2).liked_books.add(Book.objects.get(id=1))
    # User.objects.get(id=2).liked_books.add(Book.objects.get(id=3))

# Have the third user like all books
    # User.objects.get(id=3).liked_books.add(Book.objects.get(id=1))
    # User.objects.get(id=3).liked_books.add(Book.objects.get(id=2))
    # User.objects.get(id=3).liked_books.add(Book.objects.get(id=3))
    # User.objects.get(id=3).liked_books.add(Book.objects.get(id=4))
    # User.objects.get(id=3).liked_books.add(Book.objects.get(id=5))
    # User.objects.get(id=3).liked_books.add(Book.objects.get(id=6))

# Display all users who like the first book

# Display the user who uploaded the first book

# Display all users who like the second book

# Display the user who uploaded the second book