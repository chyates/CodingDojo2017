# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect


# Create your views here.
def index(request):
    if 'submit' in request.session:
        request.session['submit'] += 1
    else: 
        request.session['submit'] = 1
    return render(request, 'survey/index.html')

def process(request):
    request.session['summary'] = {
        'yourName': request.POST['yourName'],
        'location' : request.POST['location'],
        'favLang': request.POST['favLang'],
        'comments': request.POST['addlComm']
    }

    return redirect(success)

def success(request):
    return render(request, 'survey/results.html')

def reset(request):
    del request.session['submit']
    del request.session['summary']
    return redirect(index)