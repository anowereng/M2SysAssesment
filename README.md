# Image Download Urls and Base 64 Convert

### Project Folder Structure
    .
    ├── M2SysAssesent.API                  
    │   ├── wwwroot                             # contains upload images
    │   ├── Conrollers                          
    │        └── ImageController                # Download request (POST) , base64 image (GET) End API apply here. 
    └── ......
    ├── M2SysAssesent.Services                  
    │   ├── Common 
    |   |     └── Enums                         # All enums ( image type) contains here
    |   |     └── Extensions                    #  Extensions apply for duplicate find out and list empty check .   
    |   |     └── Helper                        # API Response and hard code message apply here . 
    │   ├── RequestModel                       
    |   ├── ResponseModel                       
    |   ├── Services
    └── ......
    
### Tools and packages

```
.net6.0
Swashbuckle.AspNetCore Ver.6.2.3
Microsoft.Extensions.DependencyInjection.Abstractions

```
[Run your project in vs 2022]

### Installation

For run your project in .NET CLI type 
``
dotnet run M2SysAssesment.API.csproj
``

![image](https://user-images.githubusercontent.com/14024760/213252814-23e3fcf4-37de-4dba-8ba3-881d19034ea1.png)

![image](https://user-images.githubusercontent.com/14024760/213253087-e8535338-31f1-4d40-a7b7-9e8ceb2c7c05.png)

Paste Browser 
```
https://localhost:7135/swagger/index.html
```
![image](https://user-images.githubusercontent.com/14024760/213257188-7e8daea1-060a-4d76-b030-74e25e1b7f82.png)


### Demo Data for test 

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


