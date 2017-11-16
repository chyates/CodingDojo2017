# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import Course
from django.shortcuts import render, redirect

# Create your views here.
def index(request):
    context = {
        'courses' : Course.objects.all()
    }
    return render(request, 'course_lib/index.html', context)

def add(request):
    Course.objects.create(
        name = request.POST['name'],
        desc = request.POST['desc']
    )

    return redirect('/courses')

def delete (request, id):
    context = {
        'course' : Course.objects.get(id=id)
    }
    return render(request, 'course_lib/delete.html', context)

def destroy (request, id):
    Course.objects.get(id=id).delete()
    return redirect('/courses')