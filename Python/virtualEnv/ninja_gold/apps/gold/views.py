# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
import random

# Create your views here.
def index(request):
    if 'gold' not in request.session:
        request.session['gold'] = 0
    if 'activities' not in request.session:
        request.session['activities'] = []

    return render(request, 'gold/index.html')

def process_gold(request):
    activity = ''

    if request.POST['building'] == 'farm':
        gold = random.randrange(10,21)
    elif request.POST['building'] == 'cave':
        gold = random.randrange(5,11)
    elif request.POST['building'] == 'house':
        gold = random.randrange(2,6)
    elif request.POST['building'] == 'casino':
        gold = random.randrange(-50,51)

    if gold >= 0:
        activity += 'Earned ' + str(gold) + ' gold from the ' + str(request.POST['building'])
        print activity
    else:
        activity += 'Entered a casino and lost ' + str(gold) + ' gold. Ouch!'
        print activity
        
    request.session['gold'] += gold
    request.session['activities'].insert(0, activity)

    return redirect(index)