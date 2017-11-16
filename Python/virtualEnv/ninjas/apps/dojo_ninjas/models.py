# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class Dojo(models.Model):
    name = models.CharField(max_length=255)
    city = models.CharField(max_length=255)
    state = models.CharField(max_length=255)
    desc = models.TextField(default='some_string')

class Ninja(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    dojo = models.ForeignKey(Dojo, related_name="ninjas")

# 1. Create 3 Dojos:
    # Dojo.objects.create(name="Test1", city="Chicago", state="IL")
    # Dojo.objects.create(name="Test2", city="Boston", state="MA")
    # Dojo.objects.create(name="Test3", city="Philly", state="PA")

# 2. Delete those Dojos

# 3. Create 3 add'l Dojos
    # Dojo.objects.create(name="CodingDojo Silicon Valley", city="Mountain View", state="CA") id is 4
    # Dojo.objects.create(name="CodingDojo Seattle", city="Seattle", state="WA") id is 5
    # Dojo.objects.create(name="CodingDojo New York", city="New York", state="NY") id is 6

# 4. Create 3 ninjas under the first Dojo
    # Ninja.objects.create(dojo=Dojo.objects.get(id=4), first_name="Steven", last_name="Universe")
    # Ninja.objects.create(dojo=Dojo.objects.get(id=4), first_name="Greg", last_name="Universe")
    # Ninja.objects.create(dojo=Dojo.objects.get(id=4), first_name="Rose", last_name="Quartz")

# 5. Create 3 ninjas under the second Dojo
    # Ninja.objects.create(dojo=Dojo.objects.get(id=5), first_name="Alfred", last_name="Pennyworth")
    # Ninja.objects.create(dojo=Dojo.objects.get(id=5), first_name="Bruce", last_name="Wayne")
    # Ninja.objects.create(dojo=Dojo.objects.get(id=5), first_name="Pamela", last_name="Isley")

# 6. Create 3 ninjas under the third Dojo
    # Ninja.objects.create(dojo=Dojo.objects.get(id=6), first_name="Temperance", last_name="Brennan")
    # Ninja.objects.create(dojo=Dojo.objects.get(id=6), first_name="Seeley", last_name="Booth")
    # Ninja.objects.create(dojo=Dojo.objects.get(id=6), first_name="Angela", last_name="Montenegro")

# 7. Retrieve all ninjas under the first Dojo
    #Dojo.objects.first().ninjas.all()

# 8. Retrieve all ninjas under the last Dojo
    #Dojo.objects.last().ninjas.all()

# ------ NOT IN DJANGO SHELL ------
# 9. Add a new field in the Dojo class called 'desc', can take long text rather than 255 characters
    # a. Run appropriate migration commands (forward engineer)
    # b. Run the migraction files
    # c. Check records to make sure the new field was added successfully 