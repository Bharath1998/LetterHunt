# Analytics 

## Methodology

### Step 1 - UnityWebRequest
Collect data during the game. When the player dies / level ends, send the data using a UnityWebRequest API’s POST request to MongoDB Realm endpoint.

### Step 2 - MongoDB Realm App Service
Create an App Service function to serve an end-point (this service has access to the Atlas cluster created to store the data). The function gets the data from the received request, creates an object, and sends it to the MongoDB Atlas cluster.





### Step 3 - MongoDB Atlas
This cluster stores the data received from the App Service function.

### Step 4 - Python Matplotlib
The data is exported as a JSON or CSV file. The Python Matplotlib package is used to generate charts and to analyze the data. The packages like Numpy, Pandas, etc are used to support this process.
