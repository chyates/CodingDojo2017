# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User
from ..reviews.models import Review, Book
from django.core.urlresolvers import reverse
from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
import re 

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')


def index(request):
    return render(request, 'users/index.html')

def register(request):
    isValid = True

    first_name = request.POST['first_name']
    last_name = request.POST['last_name']
    email = request.POST['email']
    username = request.POST['username']
    password = request.POST['password']
    confirmPassword = request.POST['confirm_password']

    if len(first_name) < 2 or len(last_name) < 2:
        isValid = False
        messages.error(request, "Name field cannot be less than 2 characters")

    if any(char.isdigit() for char in first_name) or any(char.isdigit() for char in last_name):
        isValid = False
        messages.error(request, "Names cannot contain numbers")

    if not EMAIL_REGEX.match(email):
        isValid = False
        messages.error(request, "Email is not valid")

    if len(password) < 8:
        isValid = False
        messages.error(request, "Password must be longer than 8 characters")

    if password != confirmPassword:
        isValid = False
        messages.error(request, "Passwords must match")

    if isValid == False:
        messages.error(request, "Registration failed, please fix errors")
        return redirect('/')

    
    user = User.objects.create(
        first_name = first_name,
        last_name = last_name,
        email = email,
        username = username,
        password = password)

    request.session['id'] = user.id
    return redirect(reverse('review:index'))

def success(request, id):
    try:
        request.session['id']
    except KeyError:
        redirect ('/')

    context = {
        'user' : User.objects.get(id=request.session['id'])
    }

    return render(request, 'users/success.html', context)

def show(request, id):
    user = User.objects.get(id=id)
    unique_reviews = user.reviews_left.all().values("book").distinct()
    unique_books = []
    for book in unique_reviews:
        unique_books.append(Book.objects.get(id=book['book']))
    context = {
        'user' : user,
        'unique_book_reviews' : unique_books
    }

    return render(request, 'users/user.html', context)

def auth(request):
    user = User.objects.get(username=request.POST['username'], password=request.POST['password'])
    if user is not None:
        request.session['id'] = user.id
        return redirect(reverse('review:index'))
    else:
        messages.error(request, 'User does not exist, please try again')
        return redirect('/login')

def logout(request):
    request.session.clear()
    return redirect('/')