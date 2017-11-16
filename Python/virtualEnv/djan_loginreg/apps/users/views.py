# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User
from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from django.contrib.auth import authenticate
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

# Create your views here.
def index(request):
    return render(request, 'users/index.html')

def success(request):
    try: 
        request.session['id']
    except:
        return redirect('/')

    context = {
        'user' : User.objects.get(id=request.session['id'])
    }

    return render(request, 'users/success.html', context)

def register(request):
    isValid = True

    first_name = request.POST['first_name']
    last_name = request.POST['last_name']
    email = request.POST['email']
    username = request.POST['username']
    password = request.POST['password']
    confirmPassword = request.POST['confirm_password']

    if len(first_name) < 2:
        isValid = False
        messages.error(request, "First name cannot be fewer than 2 characters")
    if len(last_name) < 2:
        isValid = False
        messages.error(request, "Last name cannot be fewer than 2 characters")
    if not EMAIL_REGEX.match(email):
        isValid = False
        messages.error(request, "Email is not valid")
    if len(password) < 8:
        isValid = False
        messages.error(request, "Password must be longer than 8 characters")
    if password != confirmPassword:
        isValid = False

    if isValid == False:
        return redirect('/')

    User.objects.create(
        first_name = first_name,
        last_name = last_name,
        email = email,
        username = username,
        password = password
    )
    
    request.session['id'] = user.id
    return redirect('/success')

def login(request):
    user = User.objects.get(username=request.POST['username'], password = request.POST['password'])
    if user is not None:
        request.session['id'] = user.id
        return redirect('/success')
    else: 
        messages.error(request, "User does not exist")
        return redirect('/')

def logout(request):
    request.session.clear()
    return redirect('/')