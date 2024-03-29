from django.http import JsonResponse
from rest_framework import status
from rest_framework.decorators import api_view
from rest_framework.response import Response
from .models import Itemtest
from .serializers import ItemtestSerializer

# test end point


def test_view(request):
    body = request.body
    return JsonResponse({"test":"this is a test msg with functionsl view"})


@api_view(['GET','POST'])
def ser_test2(request):
    if request.method == 'GET':
        try:
            Itemtestdata = Itemtest.objects.all()
            seriaier = ItemtestSerializer(Itemtestdata, many=True)
        except:
            return Response(status=status.HTTP_404_NOT_FOUND)

        return Response(seriaier.data)
    
    if request.method == 'POST':
        ser = ItemtestSerializer(data= request.data)
        if ser.is_valid():
            print("valid model found")
            try:
                ser.save()
                return Response(ser.data, status=status.HTTP_201_CREATED)
            except:
                print("save error")
                return Response("Action failed",status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        else:
            print("in valid model")
            return Response("Action failed",status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET','PUT','DELETE'])
def Item_details2(request, id):
    try:
        Itemtest =Itemtest.objects.get(pk=id)

    except Itemtest.DoesNotExist:
        return Response(status=status.HTTP_404_NOT_FOUND)


    if request.method == 'GET':
        serializes = ItemtestSerializer(Itemtest)
        return Response(serializes.data)
    elif request.method == 'PUT':
        serializers = ItemtestSerializer(Itemtest,data=request.data)
        if serializers.is_valid():
            serializers.save()
            print("model updated")
            return Response(serializers.data,status=status.HTTP_200_OK)
        print("model is in invalid")
        return Response(serializers.errors,status=status.HTTP_400_BAD_REQUEST)
    elif request.method == 'DELETE':
        Itemtest.delete()
        return Response(status=status.HTTP_204_NO_CONTENT)