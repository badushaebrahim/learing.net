from rest_framework import serializers
from .models import Itemtest

class ItemtestSerializer(serializers.ModelSerializer):
    class Meta:
        model = Itemtest
        fields = ['id','title','discription']