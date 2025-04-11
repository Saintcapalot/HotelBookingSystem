# 🏨 Hotel Booking System – Arbeidskrav 2

Dette er et konsollbasert administrasjonssystem utviklet i C# som en del av Arbeidskrav 2 i OOP2025. Systemet gjør det mulig å registrere og administrere kunder, gjester, rom, bookinger, arrangementer og måltider. Brukeren får også tilgang til rapporter og funksjoner for sikkerhetskopiering og gjenoppretting.

---

## 👥 Bidragsytere

### 🦇 Marcos

**Bidrag:**

Jeg hadde ansvar for å sette opp hele prosjektstrukturen og utforme README-filen. Jeg utviklet all funksjonalitet knyttet til **kunder** og **gjester**, inkludert modellene og tjenestene med full CRUD-støtte. Jeg implementerte også **romadministrasjon**, inkludert funksjoner for å opprette og vise ledige rom. Til slutt lagde jeg rapportene for **mest brukte rom** og **mest lønnsomme kunde**, samt jobbet sammen med Shahzil med **feilhåndtering og validering**.

**Refleksjon:**

Prosjektet styrket forståelsen min for OOP-prinsipper, tjenestelag og strukturert kode i større C#-prosjekter. Det vanskeligste var å sette sammen alle delene fra hver deltaker til et helhetlig program. Spesielt menyoppsettet og koblingen mellom tjenester og modeller skapte utfordringer. Her fikk vi mye hjelp fra **ChatGPT** som veileder. Fremover ønsker jeg å fokusere på testing og refaktorering.

---

### 🧠 Shahzil

**Bidrag:**

Jeg utviklet all funksjonalitet relatert til **bookinger, arrangementer og måltider** – inkludert modeller, tjenester og logikk for hvordan entitetene kobles sammen. Jeg sørget også for at måltider kunne knyttes til arrangementer. I tillegg samarbeidet jeg med Marcos for å sikre god **feilhåndtering og validering**.

**Refleksjon:**

Det mest verdifulle i dette prosjektet var å lære hvordan flere deler og entiteter samhandler i en større applikasjon. Vi støtte på utfordringer med å koble sammen våre individuelle deler og strukturere menyen på en brukervennlig måte. For å løse dette brukte vi ChatGPT aktivt som veileder til å forstå feilmeldinger og strukturere menyvalg. Dette har lært meg å jobbe mer strukturert, og jeg ser frem til å lære mer om databaser og GUI.

---

## 🤖 AI-prompter brukt

Vi brukte ChatGPT aktivt i prosjektet, spesielt til følgende:

- Feilsøking når vi støtte på kompileringsfeil
- Strukturering av `MainMenu` og deling av ansvar mellom oss
- Inspirasjon til hvordan CRUD-tjenester og modeller kunne lages

**Eksempelprompt:**

> *"Kan du hjelpe oss med å lage en MainMenu-klasse som kobler sammen klient-, gjeste- og bookingtjenestene våre med en meny for brukeren? Vi har allerede implementert CRUD-tjenester for hver modell."*

---

## ⚙️ Setup-instruksjoner

### 📦 Krav

- .NET 6 SDK eller nyere
- Windows (konsollapp – ikke WPF)
- Ingen database kreves – data lagres i minnet og kan lagres til JSON

### 🚀 Starte prosjektet

1. Åpne prosjektet i Visual Studio eller terminal.
2. Kjør kommandoen:

```bash
dotnet run
```

3. Hovedmenyen vises – her kan du navigere mellom systemets funksjoner.

### 🧪 Debug Setup

- Velg `16` i menyen for å fylle inn eksempeldata.
- Eksempeldata gjør det enklere å teste bookinger, arrangementer og måltider.

### 💾 Backup & Restore

- `17`: Sikkerhetskopierer alle entiteter til `.json`-filer.
- `18`: Gjenoppretter alle data fra `.json`.

---

## 📊 Funksjonalitet

- Full CRUD for:
    - Klienter
    - Gjester
    - Rom
    - Bookinger
    - Arrangementer
    - Måltider
- Vis ledige rom
- Eksempeldata for testing
- Backup/gjenopprett fra JSON
- Rapporter:
    - Mest brukte rom
    - Mest lønnsomme kunde

---

## 📁 Prosjektstruktur

```
HotelBookingSystem/
│
├── Models/               # Datamodeller
├── Services/             # CRUD-tjenester
├── Utilities/            # BackupManager
├── MainMenu.cs           # Hovedmenyen og UI
├── Program.cs            # Starter applikasjonen
├── README.md             # Dokumentasjonen
└── *.json                # Sikkerhetskopier (genereres under kjøring)
```

---

## 🔐 Miljøvariabler

- Ingen miljøvariabler kreves.

---

> Utviklet med 💻 og mye ☕ av Marcos og Shahzil – med veiledning fra ChatGPT.
