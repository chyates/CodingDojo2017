from django.conf.urls import url 
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^register$', views.register),
    url(r'^login$', views.login),
    url(r'^dashboard$', views.dashboard),
    url(r'^users/new$', views.new),
    url(r'^users/add$', views.add_user),
    url(r'^users/(?P<id>\d+)/add_message$', views.add_message),
    url(r'^message/(?P<id>\d+)/respond$', views.add_message_response),
    url(r'^users/(?P<id>\d+)/show$', views.show, name="show"),
    url(r'^users/edit/(?P<id>\d+)$', views.user_edit),
    url(r'^users/update/(?P<id>\d+)$', views.user_update),
    url(r'^users/(?P<id>\d+)/edit$', views.admin_edit),
    url(r'^users/(?P<id>\d+)/update$', views.admin_update),
    url(r'^users/(?P<id>\d+)/delete$', views.admin_delete),
    url(r'^users/(?P<id>\d+)/destroy$', views.admin_destroy),
    url(r'^logout$', views.logout),
]