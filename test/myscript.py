from bs4 import BeautifulSoup
import requests
from enum import Enum
import sys




class RequestType(Enum):
	GET = 1
	POST = 2




class TranslationRequest:

	Url = "https://funtranslations.com/"
	headers = {}


	"""Make a request to Url specified for translation service"""
	def __init__(self):
		self.headers = self.GetHeaders()


	def GetHeaders(self):

		PHPSESSID = "PHPSESSID"
		content_Type = "multipart/form-data; boundary=----WebKitFormBoundaryAweEkMBiilYiKaSy"

		response = self.MakeRequest(self.Url)

		if response:
			# cookie = response.cookies[PHPSESSID] #Dynamic dont work
			cookie = "f5blbt8dufqll7hn0fv44684dk" #Could not get session work dynamically, make a request on web manually with this cookie then run the script
			return {
				"Cookie": f"{PHPSESSID}={cookie}",
				"Content-Type": f"{content_Type}",
			}
		else:
			return  None


	def GetTranlation(self, data, serviceType):
		payload = {
			"text": f"{data}",
			"submit": ""
		}

		uri = self.getUri(serviceType.lower())

		response = self.MakeRequest(uri, RequestType.POST, self.headers, payload)

		print(self.headers)

		if response is not None:
		    soup = BeautifulSoup(response.text, "html.parser")
		    translation = soup.find(id='shakespeare')

		    if translation is not None:
		        return translation.text
		    else:
		        print("Translation not found in the response.")
		        return None
		else:
		    print("Error in the request.")
		    return None


	def getUri(self, serviceType):
		return self.Url + serviceType

	def MakeRequest(self, url, requestType=RequestType.GET, headers=None, data=None):
	    try:
	        if headers is not None:
	            if requestType == RequestType.GET:
	                response = requests.get(url, headers=headers)
	            elif requestType == RequestType.POST:
	                response = requests.post(url, headers=headers, data=data)
	            else:
	                raise ValueError("Invalid request type")
	        else:
	            if requestType == RequestType.GET:
	                response = requests.get(url)
	            elif requestType == RequestType.POST:
	                response = requests.post(url, data=data)
	            else:
	                raise ValueError("Invalid request type")

	        response.raise_for_status()  # Raise an HTTPError for bad responses (4xx or 5xx)
	        return response
	    except requests.exceptions.RequestException as e:
	        print(f"Error making request: {e}")
	        return None



def main():

	# Get the command-line arguments (excluding the script name itself)
	args = sys.argv[1:]

	if (len(args) > 1):
		text = args[0]
		serviceType = args[1]

		translator = TranslationRequest()

		response = translator.GetTranlation(text, serviceType)

		print("Translated Text = ", response)

	else:
		print("No Agrgument provided!!")



if __name__ == '__main__':
	main()







# link = "https://funtranslations.com/shakespeare"

# headers = {
# 	    "Cookie": f"PHPSESSID=45b0m5186r0tf5mhudq4r7jal8",
#     	"Referer": "https://funtranslations.com/shakespeare",
#     	"Content-Type": "multipart/form-data; boundary=----WebKitFormBoundaryAweEkMBiilYiKaSy"
#     	}


# payload = {
#     "text": "hello there friend",
#     "submit": ""
# }

# response = requests.post(link, headers = headers, data = payload )

# print(response.text)


# soup = BeautifulSoup(response.text, 'html.parser')

# # # Save HTML to a file
# # with open("hello.html", "w", encoding="utf-8") as htmlFile:
# #     htmlFile.write(soup.prettify())


# translation = soup.find(id='shakespeare')

# print(translation)

# payload = {
#     "text": "hello there friend",
#     "submit": ""
# }

