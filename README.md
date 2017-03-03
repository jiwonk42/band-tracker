# _Band Tracker_

#### _3.3.2017_

#### By _**Jiwon Kang**_

## Description

_This application allows users to add multiple bands to a venue and multiple venues to a band_

## Specifications: Band.cs

### The GetAll method will return 0 list if the list of band is empty in the beginning
    * input: {}
    * output: 0

### The Equals method will return true if there are two bands that are the same
    * input: {"Pentatonix", "Pop", "Problem"}{"Pentatonix", "Pop", "Problem"}
    * output: true

### The GetAll method will return the output as same as the input if the band was saved in the database
    * input: {"Pentatonix", "Pop", "Problem"}
    * output: "Pentatonix" "Pop" "Problem"

### The GetId method will return 0 if the band is assigned to an object.
    * input: {"Pentatonix", "Pop", "Problem"}
    * output: 0

### The AddVenues and GetVenues will return venue(s) if added to a Band.
    * input: {"Pentatonix", "Pop", "Problem"}, "Meany Hall"
    * output: "Meany Hall"

### The GetAll method will return a list of all bands
    * input: {"Pentatonix", "Pop", "Problem"}, {"Evanescence", "Rock", "Bring Me To Life"}
    * output: {"Pentatonix", "Pop", "Problem"}, {"Evanescence", "Rock", "Bring Me To Life"}


## Setup Instructions

### Importing databases with SSMS
* Open SSMS
* Select File > Open > File and select band_tracker.sql and band_tracker_test.sql file
* If the database does not already exist, add the following lines to the top of the script file: CREATE DATABASE [your_database_name]
GO
* Save the file
* Click: Execute
* Verify that the database has been created and the schema and/or data imported

### Viewing application
* Requires DNU, DNX, and Mono
Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server ("dnx test" for running tests)
* Navigate to http://localhost:5004 in web browser of choice


## Support and contact details

_Contact: Jiwon Kang at jiwonk42@gmail.com_

## Technologies Used

_HTML, CSS, Nancy, Razor, C#, SQL Database_

### License

*MIT*

Copyright (c) 2017 **_Jiwon Kang_**
