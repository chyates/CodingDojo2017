# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect


# Create your views here.
def index(request):
    return HttpResponse('Placeholder to later display all the list of blogs')

def new(request):
    return HttpResponse('Placeholder to display a new form to create a blog')

def create(request):
    return redirect(index)

def show(request, number):
    return HttpResponse('Placeholder to display blog '+ number)

def edit (request, number):
    return HttpResponse('Placeholder to edit blog '+ number)

def destroy(request, number):
    return redirect(index)