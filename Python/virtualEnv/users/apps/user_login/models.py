# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email_address = models.CharField(max_length=255)
    age = models.IntegerField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)


# 1. Retrieve all users
    #User.objects.all()

# 2. Retrieve last user
    #User.objects.last()

# 3. Create user records
    #User.objects.create(first_name="Doreen", last_name="Green", email_address="squirrelgurl@gmail.com", age="23")
    #User.objects.create(first_name="Nancy", last_name="White", email_address="thorcat@gmail.com", age="22")
    #User.objects.create(first_name="Koi", last_name="Boy", email_address="fsheyes@gmail.com", age="24")
    #User.objects.create(first_name="Tippy", last_name="Toe", email_address="anklebiter@gmail.com", age="3")
    #User.objects.create(first_name="Chipmunk", last_name="Hunk", email_address="tomas@gmail.com", age="26")

# 4. Retrieve first user
    #User.objects.first()

# 5. Sort users by first name
    #User.objects.order_by("first_name")

# 6. Retrieve record of user whose id=3 and update said user's last_name to something else
    # u = User.objects.get(id=3)
    # u.last_name="Johnson"
    # u.save()

# 7. Delete a user whose id=4
    # u = user.objects.get(id=4)
    # u.delete()