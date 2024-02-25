from bs4 import BeautifulSoup
import requests

link = "https://funtranslations.com/shakespeare"

headers = {
	    "Cookie": f"PHPSESSID=fsr2fgmrmq1ekn89cbeups686s; _gid=GA1.2.1927358474.1708863653; _gat_UA-55120374-1=1; _ga=GA1.1.469911956.1708593713; __gads=ID=4a0581fb75b81f94:T=1708593712:RT=1708863653:S=ALNI_MaA-3tiHdBtW77ZxLcb3IqfEsENCA; __gpi=UID=00000d0d50ba3494:T=1708593712:RT=1708863653:S=ALNI_MZsCNeRewm7yjeorXtfCvzn5vkluA; __eoi=ID=3c00f35a1449604b:T=1708593712:RT=1708863653:S=AA-AfjZLWBzlBxJSejDhiwPY8Kjq; FCNEC=%5B%5B%22AKsRol9NOXuBiDRLKy01q-aVYEDna2LwHug2kIEndy6VgJ2bUlJNY7WpjkbrWMtf2jHMf0Sph-GBD2N-Tw5_9Jn2T_XnFTTub1tjz1-1FCw19jpD6IMFLJZsSxII_NrppX4-KnqT7ZSmVEmjkjTTWUyXTXnUyFwbLA%3D%3D%22%5D%5D; _ga_YBS2HG03MC=GS1.1.1708862618.3.1.1708863683.29.0.0",
    	"Referer": "https://funtranslations.com/shakespeare",
    	"Content-Type": "multipart/form-data; boundary=----WebKitFormBoundaryAweEkMBiilYiKaSy"
    	}


payload = {
    "text": "hello there friend",
    "submit": ""
}

response = requests.post(link, headers = headers, data = payload )

print(response.text)


soup = BeautifulSoup(response.text, 'html.parser')

# Save HTML to a file
with open("hello.html", "w", encoding="utf-8") as htmlFile:
    htmlFile.write(soup.prettify())


translation = soup.find(id='shakespeare')

print(translation)