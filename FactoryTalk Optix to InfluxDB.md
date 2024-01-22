Creating a REST API with Optix

# Contents
[1.	GET request	1](#_toc153306524)

[2.	Installing InfluxDB on windows	13](#_toc153306525)

[2.1.	Inject your first data with node-red	16](#_toc153306526)

[2.2.	Injecting to InfluxDB from command line	18](#_toc153306527)

[3.	POST request to local InfluxDB	21](#_toc153306528)

[4.	POST request to remote InfluxDB	24](#_toc153306529)



1. # <a name="_toc153306524"></a>GET request
Create a new Optix project

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.001.png)

Go to libraries

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.002.png)

Drag and Drop REST API Client to NetLogic

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.003.png)

Now let’s go to UI Main window and add a button

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.004.png)

Click on the button to see the properties and add a Mouse Click event with the URL of the API

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.005.png)

First of all we have to test these API URL, we are using node red here, to create an API that returns a random number between 1 and 10

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.006.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.007.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.008.png)

Now let’s test the Optix runtime

This is working fine

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.009.png)

But we need to get the data on Optix

Let’s open the C# script

![A screenshot of a computer screen

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.010.png)

Let’s create a new variable to store the response data

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.011.png)

And change variable type

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.012.png)

Now introduce the variable somehow on the script

var Variable1 = Project.Current.GetVariable("Model/Variable1");

So you can update the variable value like this

Variable1.Value = System.Text.Encoding.UTF8.GetString(Response); 

Were response is the result of the Http request

We can introduce our variable for instance here

![A computer screen with text

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.013.png)

Like this

![A screen shot of a computer code

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.014.png)

Save the file

![A screenshot of a computer program

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.015.png)

2023-12-08 09:17:07.807;NetHelper;222;Warning;16;User .NET solution failed to build:

C:\Users\xavier.florensa\Documents\Marketing\Producte\Software\Optix\REST\_API\_GET\_v0\ProjectFiles\NetSolution\RESTApiClient.cs(152,39): error CS1002: ; expected [C:\Users\xavier.florensa\Documents\Marketing\Producte\Software\Optix\REST\_API\_GET\_v0\ProjectFiles\NetSolution\REST\_API\_GET\_v0.csproj]

Let’s correct this

Now introduce a text box

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.016.png)

And link to Variable1

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.017.png)

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.018.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.019.png)

Let’s test the application

![A screenshot of a software

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.020.png)

Voilà

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.021.png)

Not let’s try to get the http response on that Textbox

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.022.png)

Voilà, it works

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.023.png)

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.024.png)

We have created a API Rest client to perform a GET Http request

As you can see on this video

<https://youtu.be/-jf5SwSq8Us>
1. # <a name="_toc153306525"></a>Installing InfluxDB on windows

Using PowerShell in Administrator mode

Download with this command

**wget https://dl.influxdata.com/influxdb/releases/influxdb2-2.7.3-windows.zip -UseBasicParsing -OutFile influxdb2-2.7.3-windows.zip**

**Expand-Archive .\influxdb2-2.7.3-windows.zip -DestinationPath 'C:\Program Files\InfluxData\influxdb\'**

From this guide

<https://portal.influxdata.com/downloads/>

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.025.png)

\> cd -Path 'C:\Program Files\InfluxData\influxdb'

\> ./influxd

cd -Path 'C:\Program Files\InfluxData\influxdb'

./influxd

Open an explorer with localhost and port 8086

Username

xavier

Password

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.026.png)

Start building your influxdb use cases

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.027.png)

API tocken

MwQvFkNF8uI\_Yx8327ohwgDG2qHBhO9ZbAqbpFPcFRX6amE9SooSyxAiA9zofuxj8c\_C26cf-zGmMeLyGYKgHA==

Select Quickstart

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.028.png)
1. ## <a name="_toc151984162"></a><a name="_toc153306526"></a>Inject your first data with node-red
![A close-up of a tag

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.029.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.030.png)

Let’s try to inject to INfluxDB using an Http request

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.031.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.032.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.033.png)
1. ## <a name="_toc153306527"></a>Injecting to InfluxDB from command line
Now let’s try to build the http request ourselves. From windows command line

curl -POST "http://127.0.0.1:8086/api/v2/write?org=Risoul&bucket=PLC&precision=s" --header "Authorization: Token MwQvFkNF8uI\_Yx8327ohwgDG2qHBhO9ZbAqbpFPcFRX6amE9SooSyxAiA9zofuxj8c\_C26cf-zGmMeLyGYKgHA==" --data-raw "plc\_data,host=host1 IoT\_data=2324"

![A black screen with white text

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.034.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.035.png)

Let’s do this from Node-RED

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.036.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.037.png)

msg.payload = "plc\_data,host=host1 IoT\_data=1234";

msg.headers = {};

msg.headers['Authorization'] = 'Token MwQvFkNF8uI\_Yx8327ohwgDG2qHBhO9ZbAqbpFPcFRX6amE9SooSyxAiA9zofuxj8c\_C26cf-zGmMeLyGYKgHA==';

msg.headers['Content-Type'] = 'text/plain; charset=utf-8';

msg.headers['Accept'] = 'application/json';

return msg;

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.038.png)

Success

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.039.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.040.png)

Now, let’s try to do this from Factory Talk Optix
1. # <a name="_toc153306528"></a>POST request to local InfluxDB
First let’s try the right http request

API token example

c4K4HCsdkgH\_9Vv1zBDLJ2ay8QR9ORkYTIPTclHo7PI8--BPcuhEBQkb0sl5QCbAEVozZgzuA9vWk2iHnYxijg==

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.041.png)

curl -POST "http://127.0.0.1:8086/api/v2/write?org=Risoul&bucket=SEMINARI&precision=s" --header "Authorization: Token 3fIg3FPeLRzm3nALax4VZdBLW4wGqUUbFhrHsSzBG9wSiiDyMVuuwj\_9hKwb0v2xEi\_r7K\_VhndhDEdwQTiR9g==" --data-raw "optix,host=host1 IoT\_data=333"

With this result

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.042.png)

Build same project as before but with POST method

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.043.png)

**apiUrl**

<http://127.0.0.1:8086/api/v2/write?org=Risoul&bucket=SEMINARI&precision=s>

**Request Body**

plc\_data,host=host1 IoT\_data=232

**bearer Token**

3fIg3FPeLRzm3nALax4VZdBLW4wGqUUbFhrHsSzBG9wSiiDyMVuuwj\_9hKwb0v2xEi\_r7K\_VhndhDEdwQTiR9g==

**Content type**

text/plain

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.044.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.045.png)

As you can see here

<https://youtu.be/nqSctOoieOk>
1. # <a name="_toc153306529"></a>POST request to remote InfluxDB

You only have to change the URL address, organization, etc, and pay attention to this little change

Local injection

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.046.png)

Remote injection

![](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.047.png)

So if you do so, you will have success

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.048.png)

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.049.png)

But if you do not make the change from Bearer to Token, you will get this error

![A screenshot of a computer

Description automatically generated](Aspose.Words.a0799ba4-5aa3-4328-a3eb-fed0b7901e56.050.png)











Xavier FlorensaAutomation SpecialistRisoul Ibérica
