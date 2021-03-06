from django.conf.urls import url 
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^courses$', views.index),
    url(r'^courses/add$', views.add),
    url(r'^courses/delete/(?P<id>\d+)$', views.delete),
    url(r'^courses/destroy/(?P<id>\d+)$', views.destroy),
]