# Asynchronous image download and base 64 convert user guideline .

## Project Folder Structure
    .
    ├── M2SysAssesent.API                  
    │   ├── wwwroot                             # contains upload images
    │   ├── Conrollers                          
    │        └── ImageController                # Download request (POST) , base64 image (GET) end point API here. 
    └── ......
    ├── M2SysAssesent.Services                  
    │   ├── Common 
    |   |     └── Enums                         
    |   |     └── Extensions                    # Extensions apply for duplicate find out and list empty check .   
    |   |     └── Helper                        # API Response functionality and constant message write here . 
    │   ├── RequestModel                       
    |   ├── ResponseModel                       
    |   ├── Services
    └── ......
    
## Tools and packages
Project is created with: 

* .net6.0 (REST API Project)
* Swashbuckle.AspNetCore Ver.6.2.3
* Microsoft.Extensions.DependencyInjection.Abstractions

[Run your project in vs 2022]

### Installation

For run your project in .NET CLI type 
``
dotnet run M2SysAssesment.API.csproj
``

![image](https://user-images.githubusercontent.com/14024760/213252814-23e3fcf4-37de-4dba-8ba3-881d19034ea1.png)

![image](https://user-images.githubusercontent.com/14024760/213253087-e8535338-31f1-4d40-a7b7-9e8ceb2c7c05.png)

Copy url (https://localhost:7135) from console and paste postman or type browser below url link . 
```
https://localhost:7135/swagger/index.html
```
![image](https://user-images.githubusercontent.com/14024760/213257188-7e8daea1-060a-4d76-b030-74e25e1b7f82.png)

## Demo Data for test 

```
{
  "imageUrls": [
   "https://i.picsum.photos/id/26/4209/2769.jpg?hmac=vcInmowFvPCyKGtV7Vfh7zWcA_Z0kStrPDW3ppP0iGI",
   "https://i.picsum.photos/id/21/3008/2008.jpg?hmac=T8DSVNvP-QldCew7WD4jj_S3mWwxZPqdF0CNPksSko4",
   "https://i.picsum.photos/id/23/3887/4899.jpg?hmac=2fo1Y0AgEkeL2juaEBqKPbnEKm_5Mp0M2nuaVERE6eE",
   "https://i.picsum.photos/id/22/4434/3729.jpg?hmac=fjZdkSMZJNFgsoDh8Qo5zdA_nSGUAWvKLyyqmEt2xs0",
   "https://i.picsum.photos/id/30/1280/901.jpg?hmac=A_hpFyEavMBB7Dsmmp53kPXKmatwM05MUDatlWSgATE",
   "https://i.picsum.photos/id/34/3872/2592.jpg?hmac=4o5QGDd7eVRX8_ISsc5ZzGrHsFYDoanmcsz7kyu8A9A",
   "https://i.picsum.photos/id/39/3456/2304.jpg?hmac=cc_VPxzydwTUbGEtpsDeo2NxCkeYQrhTLqw4TFo-dIg",
   "https://i.picsum.photos/id/42/3456/2304.jpg?hmac=dhQvd1Qp19zg26MEwYMnfz34eLnGv8meGk_lFNAJR3g"
  ],
  "maxDownloadAtOnce": 2
}
```
## API end point check

### Download request (POST)
![image](https://user-images.githubusercontent.com/14024760/213263587-9ab11cb1-3e8e-4da1-a82b-c1c72c72cd81.png)
![image](https://user-images.githubusercontent.com/14024760/213263693-516dde7c-4a86-49fe-9a33-908e5aafe55c.png)
![image](https://user-images.githubusercontent.com/14024760/213266395-a505cf3a-a0f3-4109-8475-cba9da9a81aa.png)

### Get Image By Name (GET)
![image](https://user-images.githubusercontent.com/14024760/213263746-dfdb5bbe-e2ce-4129-9354-fb88ec709de2.png)
![image](https://user-images.githubusercontent.com/14024760/213263784-e5120d43-7ca6-4a0a-9c98-205db4a07b07.png)

## Online test Base64 to Image
![Screenshot_1](https://user-images.githubusercontent.com/14024760/213265115-05cf64eb-47f5-42b3-8a26-286b476d9c4f.png)








