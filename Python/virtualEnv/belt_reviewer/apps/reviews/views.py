# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import Review, Book
from ..users.models import User
from django.core.urlresolvers import reverse
from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages

# Create your views here.
def index(request):
    all_reviews = (Review.objects.all().order_by('-created_at')[:3], Review.objects.all().order_by('-created_at')[3:])
    limit_reviews = all_reviews[0]
    unique_reviews = all_reviews[1]
    context = {
        'user' : User.objects.get(id=request.session['id']),
        'limit_reviews' : limit_reviews,
        'more_reviews' : unique_reviews
    }
    return render (request, 'reviews/books.html', context)

def add(request):
    return render(request, 'reviews/add_book.html')

def reviews(request, id):
    context = {
        'book' : Book.objects.get(id=id)
    }
    return render(request, 'reviews/reviews.html', context)

def create(request):
    isValid = True

    title = request.POST['book']
    author = request.POST['author']
    content = request.POST['review']
    rating = request.POST['rating']

    if len(title) < 1 or len(content) < 1:
        isValid = False
        messages.error(request, 'Title and review fields are required and cannot be left blank')
    if len(title) < 2:
        isValid = False
        messages.error(request, 'Titles must be at least 3 characters')
    if len(author) < 2:
        isValid = False
        messages.error(request, 'Author names must be at least 3 characters')
    if isValid == False:
        messages.error(request, 'Could not add book or review, please fix your errors')
        return redirect('/books/add')

    Review.objects.create(
        content = content,
        rating = rating,
        book = Book.objects.create(
            title = title,
            author = author,
            user = User.objects.get(id=request.session['id'])
        ),
        reviewer = User.objects.get(id=request.session['id'])
    )

    return redirect('/books')

def create_addl(request, book_id):
    thisBook = Book.objects.get(id=book_id)

    rating = request.POST['rating']
    content = request.POST['review']

    Review.objects.create(
        content = content,
        rating = rating,
        book = thisBook,
        reviewer = User.objects.get(id=request.session['id'])
    )

    return redirect('/books/'+ book_id)

def delete(request, review_id):
    Review.objects.get(id=review_id).delete()
    return redirect('/books/')