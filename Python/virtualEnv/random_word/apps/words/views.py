# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect

import random
# Create your views here.
def index(request):
    if not 'attempt' in request.session:
        request.session['attempt'] = 0
        request.session['word'] = ''
    return render(request, 'words/index.html')

def create(request):
    random_word = ''
    letters = ['p','i','c','k','a','r','n','d','o','m','w','d','s','e']
    for i in range(14):
        l_index = random.randint(0, len(letters) - 1)
        random_word += letters[l_index]
    request.session['attempt'] += 1
    request.session['word'] = random_word
    return redirect(index)

def reset(request):
    del request.session['attempt']
    del request.session['word']
    return redirect(index)
