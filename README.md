# Image Download Urls and Base 64 Convert

### Project Folder Structure
    .
    ├── M2SysAssesent.API                  
    │   ├── wwwroot                             # contains upload images
    │   ├── Conrollers                          # End-to-end, integration tests (alternatively `e2e`)
    │        └── ImageController                # Download request (POST) , base64 API End point apply here. 
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
