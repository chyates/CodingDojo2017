from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^add_city$', views.add_city),
    url(r'^details/(?P<city>[A-z]+)$', views.city_detail),
    url(r'^add_todo/(?P<city>[A-z]+)$', views.add_todo),
    url(r'^reset_todo/(?P<city>[A-z]+)$', views.reset_todo),
    url(r'^reset_trips$', views.reset_trips),
]