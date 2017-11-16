# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect


def index(request):
    if 'cities' not in request.session:
        request.session['cities'] = {}

    context = {
        'context_cities': request.session['cities']
    }

    return render(request, 'trip_master/index.html', context)

def add_city(request):
    server_city = request.POST['html_city']

    cities = request.session['cities']
    
    if server_city not in cities:
        cities[server_city] = []

    request.session['cities'] = cities

    return redirect('/')

def city_detail(request, city):
    if city not in request.session['cities']:
        return redirect('/')

    print '----------\n', request.session['cities'][city]
    context = {
        'context_city': city,
        'todo': request.session['cities'][city]
    }
    return render(request, 'trip_master/detail.html', context)


def reset_trips(request):
    request.session.clear()
    return redirect('/')

def add_todo(request, city):
    if city in request.session['cities']:
        city_dict = request.session['cities']
        todo = city_dict[city]
        todo.append(request.POST['html_todo'])
        city_dict[city] = todo
        request.session['cities'] = city_dict


    return redirect('/details/'+city)


def reset_todo(request, city):
    if city in request.session['cities']:
        city_dict = request.session['cities']
        city_dict[city] = []
        request.session['cities'] = city_dict

    return redirect('/details/'+city)

