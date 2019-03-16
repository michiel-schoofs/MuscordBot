#-----------------------------------------------------------------#
#                        import libraries                         #
#-----------------------------------------------------------------#
import json
import requests

#-----------------------------------------------------------------#
#                          definitions                            #
#-----------------------------------------------------------------#
def google_search(url):
    headers = {'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36'}
    search_response = requests.get(url, headers)
    g_results = json.loads(search_response.content.decode("utf8"))
    return g_results
    
#-----------------------------------------------------------------#
#                         instructions                            #
#-----------------------------------------------------------------#
a = google_search("https://datatank.stad.gent/4/musea/toegankelijkheidsinfo.json")

for i in a:
   print(i['Museum'])

b = []
for i in range(64):
    q = google_search("https://visit.gent.be/en/lod/poi?page=" + str(i))
    b.append(q)
    with open('C:\\Users\\X-Tra Lars\\Desktop\\Nieuwe map\\MuscordBot\\MuscordBot\\Data\\LinkedData\\data' + str(i) + '.json', 'w') as outfile:  
        json.dump(q, outfile, indent=4)
    outfile.close()

namen_lst = ['St.-Pietersabdij, oase met wijngaard',
 'STAM, het Stadsmuseum Gent',
 'Museum Dr. Guislain, te Gek!',
 'Design Museum  Gent, modern historisch',
 'De wereld van Kina: de Tuin',
 'S.M.A.K. hedendaage kunst in Gent',
 'Museum voor Schone Kunsten (MSK)',
 'Industriemuseum',
 'Huis van Alijn, de tijd ontvluchten',
 'School van Toen',
 'Kunsthal Gent']    

object_lst = []
for z in namen_lst:    
    for i in range(64):
        reads = open("C:\\Users\\X-Tra Lars\\Desktop\\Nieuwe map\\MuscordBot\\MuscordBot\\Data\\LinkedData\\data"+str(i)+".json", 'r')
        attri = json.load(reads)
        for j in attri["member"]:
            if str(j["name"]["nl"][0]).strip() == z:
                object_lst.append(j)

with open('C:\\Users\\X-Tra Lars\\Desktop\\Nieuwe map\\prototype3.json', 'w') as outfile:              
    outfile.write(json.dumps(object_lst, indent=4))
