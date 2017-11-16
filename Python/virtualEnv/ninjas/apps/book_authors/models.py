# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class Book(models.Model):
    name = models.CharField(max_length=255)
    desc = models.TextField(max_length=1000)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

class Author(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    note = models.TextField(default="some_string")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    books = models.ManyToManyField(Book, related_name = "authors")

# Create 5 books with the following names: C sharp, Java, Python, PHP, Ruby

# Create 5 different authors: Mike, Speros, John, Jadee, Jay

# Add a new field in the authors table called 'notes'.  Make this a TextField.  Successfully create and run the migration files.

# Change the name of the 5th book to C#
    # b = Book.objects.get(id=5)
    # b.name="C#"
    # b.save()

# Change the first_name of the 5th author to Ketul
    # a = Author.objects.get(id=5)
    # a.first_name="Ketul"
    # a.save()

# Assign the first author to the first 2 books
    # Books.objects.get(id=1).authors.add(Author.objects.get(id=1))
    # Books.objects.get(id=2).authors.add(Author.objects.get(id=1))

# Assign the second author to the first 3 books
    # Books.objects.get(id=1).authors.add(Author.objects.get(id=2))
    # Books.objects.get(id=2).authors.add(Author.objects.get(id=2))
    # Books.objects.get(id=3).authors.add(Author.objects.get(id=2))

# Assign the third author to the first 4 books
    #Books.objects.get(id=1).authors.add(Author.objects.get(id=3))
    #Books.objects.get(id=2).authors.add(Author.objects.get(id=3))
    #Books.objects.get(id=3).authors.add(Author.objects.get(id=3))
    #Books.objects.get(id=4).authors.add(Author.objects.get(id=3))

# Assign the fourth author to the first 5 books (or in other words, all the books)
    #Books.objects.get(id=1).authors.add(Author.objects.get(id=4))
    #Books.objects.get(id=2).authors.add(Author.objects.get(id=4))
    #Books.objects.get(id=3).authors.add(Author.objects.get(id=4))
    #Books.objects.get(id=4).authors.add(Author.objects.get(id=4))
    #Books.objects.get(id=5).authors.add(Author.objects.get(id=4))

# For the 3rd book, retrieve all the authors
    # Author.objects.filter(books=Book.objects.get(id=3))

# For the 3rd book, remove the first author

# For the 2nd book, add the 5th author as one of the authors

# Find all the books that the 3rd author is part of

# Find all the books that the 2nd author is part of