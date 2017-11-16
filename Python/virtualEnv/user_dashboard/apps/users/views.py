# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User, Message, Response
from django.shortcuts import render, redirect, HttpResponse
from django.core.urlresolvers import reverse
from django.contrib import messages

# --------------------
# - ALL LEVEL ROUTES -
# --------------------
def index(request):
    return render(request, 'users/index.html')

def register(request):
    result = User.objects.validReg(request.POST)
    if type(result) == list:
        for errors in result:
            messages.error(request, errors)
        return redirect('/')
    request.session['id'] = result.id
    print request.session['id']
    return redirect('/dashboard')

def login(request):
    result = User.objects.validLog(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/')
    request.session['id'] = result.id
    return redirect('/dashboard')

def dashboard(request):
    users = User.objects.all()
    user = User.objects.get(id=request.session['id'])

    context = {
        'users' : users,
        'user' : user
    }

    if user.admin_level == "True":
        return render(request, 'users/admin_dashboard.html', context)
    else:
        return render(request, 'users/user_dashboard.html', context)

def show(request, id):
    context = {
        'user' : User.objects.get(id=id),
        'messages' : Message.objects.exclude(poster=id),
        'responses' : Response.objects.all()
    }
    return render(request, 'users/user_profile.html', context)

def add_message(request, id):
    message = Message.objects.create(
        content = request.POST['message'],
        poster = User.objects.get(id=request.session['id']),
        posted_on = id
    )
    return redirect(reverse('show', kwargs = {'id': id}))

def add_message_response(request, id):
    message = Message.objects.get(id=id)
    response = Response.objects.create(
        content = request.POST['response'],
        message = message,
        responder = User.objects.get(id=request.session['id'])
    )
    user_id = message.posted_on
    return redirect(reverse('show', kwargs = {'id': user_id}))

def logout(request):
    request.session.clear()
    return redirect('/')

# ----------------------
# - ADMIN LEVEL ROUTES -
# ----------------------

def new(request):
    return render(request, 'users/admin_add_user.html')

def add_user(request):
    result = User.objects.admin_add(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/users/new')
    return redirect('/dashboard')

def admin_edit(request, id):
    user = User.objects.get(id=id)
    context = {
        'user' : user
    }
    return render(request, 'users/admin_edit.html', context)

def admin_update(request, id):
    result = User.objects.validInfo(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/dashboard')
    existingUser = User.objects.get(id=id)
    existingUser.first_name = request.POST['first_name']
    existingUser.last_name = request.POST['last_name']
    existingUser.email = request.POST['email']
    existingUser.admin_level = request.POST['admin_level']
    existingUser.save()
    return redirect('/dashboard')

def admin_delete(request, id):
    context = {
        'user' : User.objects.get(id=id)
    }
    return render(request, 'users/admin_delete.html', context)

def admin_destroy(request, id):
    User.objects.get(id=id).delete()
    return redirect('/dashboard')

# ---------------------
# - USER LEVEL ROUTES -
# ---------------------

def user_edit(request, id):
    user = User.objects.get(id=request.session['id'])
    context = {
        'user' : user
    }
    return render(request, 'users/user_edit.html', context)

def user_update(request, id):
    result = User.objects.validInfo(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/dashboard')
    existingUser = User.objects.get(id=id)
    existingUser.first_name = request.POST['first_name']
    existingUser.last_name = request.POST['last_name']
    existingUser.email = request.POST['email']
    existingUser.save()
    return redirect('/dashboard')