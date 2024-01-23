Creating a REST API with Optix

# Contents
[1.	GET request](#_toc153306524)

[2.	Installing InfluxDB on windows](#_toc153306525)

[2.1.	Inject your first data with node-red](#_toc153306526)

[2.2.	Injecting to InfluxDB from command line](#_toc153306527)

[3.	POST request to local InfluxDB](#_toc153306528)

[4.	POST request to remote InfluxDB	24](#_toc153306529)



# <a name="_toc153306524"></a>1. GET request
Create a new Optix project

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 001](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/036fef87-265b-40e6-8668-028b403abd71)

Go to libraries

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 002](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/6539cca2-176f-40fb-802b-7af41fbb4bbd)

Drag and Drop REST API Client to NetLogic

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 003](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/9603a5e2-814d-4f36-ab81-d47ecd66e564)

Now let’s go to UI Main window and add a button

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 004](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/23f7be58-5c6d-4d8a-af43-bc476082c59d)

Click on the button to see the properties and add a Mouse Click event with the URL of the API

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 005](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/3ec74a91-9cba-472f-a116-3433e9f67925)


First of all we have to test these API URL, we are using node red here, to create an API that returns a random number between 1 and 10

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 006](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/790457d8-1012-4709-b12d-f1b0d0481fa7)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 007](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/84679676-534b-48ad-9efd-57adceb3dcc6)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 008](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/731b864f-11bb-4df8-8963-1ccfbce585db)

Now let’s test the Optix runtime

This is working fine

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 009](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/c3228eeb-75f9-4e3b-b006-38b27dcba02a)

But we need to get the data on Optix

Let’s open the C# script

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 010](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/70d8623f-4815-4e55-b036-8d94cd81f4c2)

Let’s create a new variable to store the response data

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 011](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/044c1030-04bf-4a7e-b744-55284b4d148b)

And change variable type

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 012](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/56d3db2a-c05f-4e46-8ed6-072d304d84d6)

Now introduce the variable somehow on the script

```C#
var Variable1 = Project.Current.GetVariable("Model/Variable1");
```

So you can update the variable value like this

```C#
Variable1.Value = System.Text.Encoding.UTF8.GetString(Response); 
```

Were response is the result of the Http request

We can introduce our variable for instance here

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 013](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/1a6c3f7d-c86f-4d85-be91-f5b29337d34f)

Like this

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 014](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/d0ac6afa-27ba-4f70-9332-42e5afd081fb)

Save the file

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 015](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/7a7d772e-a7b4-416c-a528-7f207ff996e5)

2023-12-08 09:17:07.807;NetHelper;222;Warning;16;User .NET solution failed to build:

C:\Users\xavier.florensa\Documents\Marketing\Producte\Software\Optix\REST\_API\_GET\_v0\ProjectFiles\NetSolution\RESTApiClient.cs(152,39): error CS1002: ; expected [C:\Users\xavier.florensa\Documents\Marketing\Producte\Software\Optix\REST\_API\_GET\_v0\ProjectFiles\NetSolution\REST\_API\_GET\_v0.csproj]

Let’s correct this

Now introduce a text box

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 016](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/b205f163-65a0-455d-9f6f-23a7cb14ef2c)

And link to Variable1

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 017](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/c8af1e77-3421-42fa-a58f-be14ca73cf50)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 018](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/0d8b5600-0501-48dc-8aab-d8eedc1d64ab)
![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 019](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/19eb2b97-c19b-470b-a200-3af88dfdc973)

Let’s test the application

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 020](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/9845678d-bed6-4dec-9779-8feefe09dc3c)

Voilà

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 021](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/9ec225b8-2351-4ab6-bc35-f37a816bc487)

Not let’s try to get the http response on that Textbox

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 022](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/8b884393-ca29-479f-a1c7-20a81e0e5f2f)

Voilà, it works

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 023](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/56e2a3b8-917b-46f2-a86c-32efb3969d94)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 024](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/81a96b09-f312-43c4-9313-5040e0fbec7e)

We have created a API Rest client to perform a GET Http request

As you can see on this video

<https://youtu.be/-jf5SwSq8Us>
# <a name="_toc153306525"></a>2. Installing InfluxDB on windows

Using PowerShell in Administrator mode

Download with this command

**wget https://dl.influxdata.com/influxdb/releases/influxdb2-2.7.3-windows.zip -UseBasicParsing -OutFile influxdb2-2.7.3-windows.zip**

**Expand-Archive .\influxdb2-2.7.3-windows.zip -DestinationPath 'C:\Program Files\InfluxData\influxdb\'**

From this guide

<https://portal.influxdata.com/downloads/>

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 025](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/4d6f26ab-55ec-469a-bdc3-941ab5a1150e)

\> cd -Path 'C:\Program Files\InfluxData\influxdb'

\> ./influxd

cd -Path 'C:\Program Files\InfluxData\influxdb'

./influxd

Open an explorer with localhost and port 8086

Username

xavier

Password

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 026](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/29d84063-3730-45b2-9e7d-c042a47af0af)

Start building your influxdb use cases

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 027](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/3091a8cb-04d4-4d7c-85f3-45affc1111eb)

API tocken

MwQvFkNF8uI\_Yx8327ohwgDG2qHBhO9ZbAqbpFPcFRX6amE9SooSyxAiA9zofuxj8c\_C26cf-zGmMeLyGYKgHA==

Select Quickstart

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 028](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/e0989bd3-01d6-492b-88c2-b77edd0d924d)

## <a name="_toc151984162"></a><a name="_toc153306526"></a>2.1 Inject your first data with node-red

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 029](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/2aaac974-2bc9-41a0-a67a-562839abd13b)


![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 030](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/61f99f7f-4df9-48c2-8e8e-b0f3ea0c68c7)


Let’s try to inject to INfluxDB using an Http request

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 031](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/14d8495c-cd5c-4ec7-87d5-1e3141d9ce42)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 032](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/d4970e06-2a92-4739-baf2-48c63795a0e3)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 033](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/7a4f56b0-fb46-4656-9e76-7d50e809035a)
## <a name="_toc153306527"></a>2.2 Injecting to InfluxDB from command line
Now let’s try to build the http request ourselves. From windows command line

curl -POST "http://127.0.0.1:8086/api/v2/write?org=Risoul&bucket=PLC&precision=s" --header "Authorization: Token MwQvFkNF8uI\_Yx8327ohwgDG2qHBhO9ZbAqbpFPcFRX6amE9SooSyxAiA9zofuxj8c\_C26cf-zGmMeLyGYKgHA==" --data-raw "plc\_data,host=host1 IoT\_data=2324"

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 034](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/bf7340dd-92e2-42e6-b3be-5bcef0d15b4f)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 035](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/0e51c26a-10ef-4cbc-b6fc-172322a50a05)

Let’s do this from Node-RED

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 036](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/e014b697-ca6a-44be-bda0-5fbb28420393)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 037](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/2d220228-9400-496c-b9b6-c950300bdec7)

```javascript
msg.payload = "plc\_data,host=host1 IoT\_data=1234";

msg.headers = {};

msg.headers['Authorization'] = 'Token MwQvFkNF8uI\_Yx8327ohwgDG2qHBhO9ZbAqbpFPcFRX6amE9SooSyxAiA9zofuxj8c\_C26cf-zGmMeLyGYKgHA==';

msg.headers['Content-Type'] = 'text/plain; charset=utf-8';

msg.headers['Accept'] = 'application/json';

return msg;
```
![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 038](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/fce2a548-edda-47c0-b013-5e64d9b6ce0a)

Success

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 039](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/74aed00e-8c15-4355-8c17-011fbde665c9)


![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 040](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/5c81dce5-5a17-4397-9b04-1b359e18f045)

Now, let’s try to do this from Factory Talk Optix
# <a name="_toc153306528"></a>3. POST request to local InfluxDB
First let’s try the right http request

API token example

c4K4HCsdkgH\_9Vv1zBDLJ2ay8QR9ORkYTIPTclHo7PI8--BPcuhEBQkb0sl5QCbAEVozZgzuA9vWk2iHnYxijg==

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 041](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/fc848570-c6f5-4d63-a92c-31bdcffd12d8)

curl -POST "http://127.0.0.1:8086/api/v2/write?org=Risoul&bucket=SEMINARI&precision=s" --header "Authorization: Token 3fIg3FPeLRzm3nALax4VZdBLW4wGqUUbFhrHsSzBG9wSiiDyMVuuwj\_9hKwb0v2xEi\_r7K\_VhndhDEdwQTiR9g==" --data-raw "optix,host=host1 IoT\_data=333"

With this result

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 042](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/2c136283-296d-4183-976f-2c89890a7ea8)

Build same project as before but with POST method

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 043](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/5f957042-1dd2-4dad-9c34-9ea7b95c53ac)

**apiUrl**

<http://127.0.0.1:8086/api/v2/write?org=Risoul&bucket=SEMINARI&precision=s>

**Request Body**

plc\_data,host=host1 IoT\_data=232

**bearer Token**

3fIg3FPeLRzm3nALax4VZdBLW4wGqUUbFhrHsSzBG9wSiiDyMVuuwj\_9hKwb0v2xEi\_r7K\_VhndhDEdwQTiR9g==

**Content type**

text/plain

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 044](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/cc4e88ba-c657-4cb1-9352-e207bff86822)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 045](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/7a48d6c5-43b1-4a9d-bb8d-fae9bf1f030c)

As you can see here

<https://youtu.be/nqSctOoieOk>
# <a name="_toc153306529"></a>4. POST request to remote InfluxDB

You only have to change the URL address, organization, etc, and pay attention to this little change

Local injection

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 046](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/8d4017de-fbba-4d0a-8c3d-54a3afdffa5f)

Remote injection

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 047](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/6e7d0a88-f8b0-41e2-a220-5c3b0f64a830)


So if you do so, you will have success

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 048](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/c0bff68f-df0c-4552-9625-4cdcbd62aa79)

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 049](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/71dbb24b-7d17-4806-b406-fcbadcb39280)

But if you do not make the change from Bearer to Token, you will get this error

![Aspose Words a0799ba4-5aa3-4328-a3eb-fed0b7901e56 050](https://github.com/xavierflorensa/Optix_2_InfluxDB_v7/assets/55208134/1813fc53-1208-4e82-9ff0-5079a2c715bf)











Xavier Florensa      Automation Specialist      Risoul Ibérica
