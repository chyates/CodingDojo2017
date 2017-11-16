# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse
from time import gmtime, strftime, localtime

# Create your views here.
def index(request):
    context = {
        "time": strftime("%b %d %Y %I:%M %p %z", localtime())
    }
    return render(request, 'current_time/index.html', context)