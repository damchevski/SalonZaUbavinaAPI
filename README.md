# SalonZaUbavinaAPI

# Kreiranje termin *DateTime se prakja kako string, da se zapazi formatot*
  http://localhost:5000/api/Schedule/CreateSchedule
  Body:
    {
    "DateTime" : "11.05.2022 12:00",
    "User": "ane damch",
    "ScheduleDescription": "Test desc cupkanje",
    "PhoneNumber" : "070364003",
    "UserEmail" : "damch@gmail.com"
    }

# Zimanje na site termini vo daden den *da se zapazi formatot na datumot*
  http://localhost:5000/api/Schedule/GetAllSchedulesForDate?date=11.05.2022

# Zimanje na site slobodni saati za termini na daden den *voj mesec*
  http://localhost:5000/api/Schedule/GetAllFreeTermsForDay?day=11
  
# Odobruvanje/odbivanje na termin
  http://localhost:5000/api/Schedule/MarkScheduleAs?scheduleId=4&approved=false
  - Ako sakame da go odobrime approved=true, ako sakame da go odbieme approved=false

# Zimanje detali za daden termin
  http://localhost:5000/api/Schedule/GetScheduleDetails?scheduleId=4
  
