# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User
from django.contrib.messages import error
from django.shortcuts import render, redirect, HttpResponse


# ------- GET REQUESTS --------
def index(request):
    context = {
        'users' : User.objects.all()
    }
    return render(request, 'users/index.html', context)

def new(request):
    return render(request, 'users/new_user.html')

# ------- POST REQUESTS -------
def create(request):
    errors = User.objects.validate(request.POST)
    if len(errors):
        for field, message in errors.iteritems():
            error(request, message, extra_tags=field)
            return redirect('/users/new')

    User.objects.create(
        first_name=request.POST['first_name'],
        last_name=request.POST['last_name'],
        email=request.POST['email'],)
    return redirect('/users')

def edit(request, id):
    context = {
        'user' : User.objects.get(id=id)
    }
    return render(request, 'users/edit_user.html', context)

def show(request, id):
    context = {
        'user' : User.objects.get(id=id)
    }

    return render(request, 'users/user.html', context)

def update(request, id):
    errors = User.objects.validate(request.POST)
    if len(errors):
        for field, message in errors.iteritems():
            error(request, message, extra_tags=field)
        return redirect('/users/{}/edit'.format(id))

    user_up = User.objects.get(id=id)
    user_up.first_name = request.POST['first_name']
    user_up.last_name = request.POST['last_name']
    user_up.email = request.POST['email']
    user_up.save()
    return redirect('/users')

def delete(request, id):
    User.objects.get(id=id).delete()
    return redirect('/users')