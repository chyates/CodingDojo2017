from django.conf.urls import url 
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^users$', views.index),
    url(r'^register$', views.register),
    url(r'^auth$', views.auth),
    url(r'^logout$', views.logout, name="logout"),
    url(r'^users/(?P<id>\d+)$', views.show, name="show"),
]