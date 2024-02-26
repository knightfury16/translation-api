from bs4 import BeautifulSoup
import requests

link = "https://funtranslations.com/shakespeare"

headers = {
	    "Cookie": f"PHPSESSID=fsr2fgmrmq1ekn89cbeups6s;",
    	"Referer": "https://funtranslations.com/shakespeare",
    	"Content-Type": "multipart/form-data; boundary=----WebKitFormBoundaryAweEkMBiilYiKaSy"
    	}


payload = {
    "text": "hello there friend",
    "submit": ""
}

response = requests.post(link, headers = headers, data = payload )

# print(response.text)


soup = BeautifulSoup(response.text, 'html.parser')

# Save HTML to a file
with open("hello.html", "w", encoding="utf-8") as htmlFile:
    htmlFile.write(soup.prettify())


translation = soup.find(id='shakespeare')

print(translation)