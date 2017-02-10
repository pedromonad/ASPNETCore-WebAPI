# ASP.NET Core WebApi Sample

In this repository I want to give a plain starting point at how to build a WebAPI with ASP.NET Core.

This repository contains a controller which is dealing with Moviess. You can GET/POST/PUT/PATCH and DELETE them.

Hope this helps.

See the examples here: 

## GET all Moviess

``` http://localhost:29435/api/Movies ```

![ASPNETCOREWebAPIGET](./_gitAssets/get.jpg)

## GET single Movies

``` http://localhost:29435/api/Movies/1 ```

![ASPNETCOREWebAPIGET](./_gitAssets/getSingle.jpg)

## POST a Movies

``` http://localhost:29435/api/Movies ```

````javascript
  {
    "street": "MyNewStreet",
    "city": "MyHomeTown",
    "zipCode": 1234
  }
```

![ASPNETCOREWebAPIGET](./_gitAssets/post.jpg)

## PUT a Movies

``` http://localhost:29435/api/Movies/5 ```

````javascript
{
    "id": 5,
    "street": "HAAALELUJAH",
    "city": "HAAALELUJAH-TOWN",
    "zipCode": 1234657
}
```

![ASPNETCOREWebAPIGET](./_gitAssets/put.jpg)


## PATCH a Movies

``` http://localhost:29435/api/Movies/4 ```

````javascript
[
    { "op": "replace", "path": "/street", "value": "PatchStreet" }
]
```

![ASPNETCOREWebAPIGET](./_gitAssets/patch.jpg)

## DELETE a Movies

``` http://localhost:29435/api/Movies ```


![ASPNETCOREWebAPIGET](./_gitAssets/delete.jpg)
