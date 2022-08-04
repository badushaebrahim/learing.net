from django.db import models

#item class


class Itemtest(models.Model):
    title = models.TextField()
    discription = models.TextField()