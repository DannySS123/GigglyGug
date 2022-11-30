Az alap elképzelés egy 2D platformer játék volt, amiben néhány pálya található.
A játék elkészítéséhez kellő építőelemek:
menü:

karakter: kép A karakter rajzát mi készítettük el, egy az interneten talált kép
 felhasználásával, amihez testet, illetve lábakat rajzoltunk.

mozgás:

karakter animációja


kamera:
a kamerát úgy akartuk, hogy játékos központú legyen, tehát a játékos mindig a képernyő központjába kerüljön
Ehhez a hierarchiában a player alá kellett tenni.
Emellett szerettük volna, ha a képernyőn emellett látszódnak az összegyűjtött
eszközök, coinok, az eltelt idő, az életek száma.
Ehhez egy canvas-t használtunk, aminek átlátszóan hagytuk a hátterét.
pálya: A pályához egy tilemap-et használtunk, amihez a tile-okat egy letöltött assetből
szereztük meg. Link. A pályák kialakításánál fő szempont volt, hogy minél változatosabban
használjuk a meglévő elemeket, hogy ne legyen egysíkú a játék.
Ehhez voltak eszközök az egyes szörnyek, a különböző hátteret díszítő elemek.
A pálya kialakításához néhány helyen az egyes mezőket elforgattuk, átméreteztük, hogy ezzel is 
több eszköz álljon rendelkezésre.

szörnyek: A játékban 3 féle szörny található, amiket az asset storeban találtunk. link
A szörnyek között található álló, egyenletesen mozgó, és a játékost követő.
A működési elvük, hogy kapnak egy collidert, és játékos collidere és a szörny collidere találkozik,
akkor egy script visszarakja a játékost
az legutolsó checkpointra.
Képek
Álló szörny: a legegyszerűbb szörny, a fent leírtakon kívül semmi mást nem kell hozzárakni.
Mozgó szörny: egyenletesen mozog balra-jobbra, illetve akár lejtőn/ emelkedőn is tud mozogni, 
amihez a dőlésszögét kell beállítani. Egy hozzá tartozó scripttel mozog, amiben minden frameben egy kicsit odébb rakja a szörnyet,
illetve ha elér a kezdőpontjától egy bizonyos távolságot, akkor visszafordul, és visszafelé megy egészen a kezdőpontig
Követő szörny: todo


Checkpointok:
A képe egy asset store-ból szerzett prefab
A célja hogy ne csak a pályák közti átmenetekben mentse el a játékos haladását a játék.
Egy colliderjük van, ami ha találkozik a játékos colliderében, akkor a respawn Position-t átállítja 
a saját pozíciójára.

háttér
A háttér képet az interneten találtuk meg Link.
A cél az volt, hogy a háttér scrollable legyen, tehát olyan kép kellett, amit ha többször
egymás mellé teszünk, akkor nem látszik a képek között az átmenet


díszítések
Az asset storeból szedtük a különböző, a pályát díszítő elemeket. Fontos volt, hogy lehessen őket a játékos és a szörnyek
elé vagy mögé tenni, ehhez az egyes elemek sorting layerét kell beállítani.

átlépés a pályák között

újraéledés: A halál két módon következhet be:
a játékos leesik a pályáról
a játékos egy szörnyhez hozzáér
mindkét esetben azt szerettük volna, ha a játékos mellett az összes szörny az eredeti helyére visszakerül.
a játékos visszakerüléséhez szükség volt egy respawnPosition-ra, és ha egy bizonyos y érték alá kerül a játékos, 
vagy hozzáér egy szörnyhez, akkor ide kerül vissza.
szörnyek újraéledése todo

Pause menü

Végső menü

pontozás:


