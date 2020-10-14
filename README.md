# OneSignalFinalDemo
 
1. Download the code and build the application using visual studio.
2. Before running the application make sure to update the Data source (in accordance with your installed instance of sqlserver) for connection string having name “UsersDB” in the webconfig. 
3. Configuring correct instance of SQL server is very important because the system will create the users required to operate it in the database.
4. Now you can run the web application either by deploying to IIS or using visual studio IIS express.
5. The demo will generate following two users
a. admin@mysite.com having password: A@12345678
b. user@mysite.com having password: U@12345678 
6. The If you want to change user email or password that can be configured with the help of webhelper class
7. The system has following functionalities
a. View all Apps
b. Create App
c. Update App
8. Functionality of View all Apps is allowed for both admin and user but the finalities of Create App and Update App is only allowed to admin.
9. Your feedback and suggestions are highly appreciated, please provide them in comments
