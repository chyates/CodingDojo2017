# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect
from time import strftime, localtime

# Create your views here.
def index(request):
    return render(request, 'add_words/index.html')

def add_word(request):
    ## 1 - convert form data into dictionary
    ## 2 - append dictionary into session

    new_word = {}
    for key, value in request.POST.iteritems():
        if key != "csrfmiddlewaretoken" and key != "big":
            new_word[key] = value
        if key == 'size':
            new_word['size'] = 'big'
        else:
            new_word['size'] = 'none'
    new_word['time'] = strftime("%b %d %Y %I:%M %p", localtime())
    
    try:
        request.session['words']
    except KeyError:
        request.session['words'] = []

    word_list = request.session['words']
    word_list.append(new_word)
    request.session['words'] = word_list

    return redirect(index)

def reset(request):
    request.session.clear()
    return redirect(index)