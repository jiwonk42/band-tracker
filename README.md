# _Band Tracker_

#### _3.3.2017_

#### By _**Jiwon Kang**_

## Description

_This application allows users to add multiple bands to a venue and multiple venues to a band_

## Specifications

### The get all method will return an empty list if the list of venues is empty in the beginning
    * input: {}
    * output: 0

### The equals method will return true if there are two venues that are the same
    * input: {"Verizon Center"}, {"Verizon Center"}
    * output: true

### The save method will assign a new id to an new instance of the venue class.
    * input: {"Verizon Center", 0}
    * output: {"Verizon Center", non zero}

### The find method will return the venue in the database.
    * input: {"Verizon Center"}
    * output: "Verizon Center"

### When the user updates the name of a venue, the update method will return the updated name
    * input: {"Meany Hall"}, {"Verizon Center"}
    * output: "Verizon Center"

### When the user deletes a venue, the delete method will return an updated list without the deleted venue
    * input: {"Verizon Center"}
    * output: {"Kane Hall", "Meany Hall", "Smith Hall"}

### The get all method will return an empty list if the list of band is empty in the beginning
    * input: {}
    * output: ""

### The equals method will return true if there are two bands that are the same
    * input: {"Pentatonix", "Pop", "Problem"}{"Pentatonix", "Pop", "Problem"}
    * output: true

### The save and get all methods will return true if the band was saved in the database
    * input: {"Pentatonix", "Pop", "Problem"}
    * output: true

### The get all method will return true if the id for the first band has an id of 1.
    input: {"Pentatonix", "Pop", "Problem"}
    output: 1

### The get all method will return a list of all bands
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
