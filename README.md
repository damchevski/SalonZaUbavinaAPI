# SalonZaUbavinaAPI

# Kreiranje termin *DateTime se prakja kako string, da se zapazi formatot (mesec.den.godina hh:mm* - POST
  http://localhost:5000/api/Appointment/CreateAppointment
  Body:
   {
    "DateTime" : "05.15.2022 13:00",
    "User": "ane damch",
    "AppointmentDescription": "Test desc cupkanje",
    "PhoneNumber" : "070364003",
    "UserEmail" : "damch@gmail.com"
	}

# Zimanje na site termini vo daden den *da se zapazi formatot na datumot (mesec.den.godina) * - GET
  http://localhost:5000/api/Appointment/GetAllAppointmentsForDate?date=05.15.2022

# Zimanje na site slobodni saati za termini na daden den *voj mesec* - GET
  http://localhost:5000/api/Appointment/GetAllFreeTermsForDay?day=11
  
# Odobruvanje na termin - POST
  http://localhost:5000/api/Appointment/MarkAppointmentAs?appointmentId=8&approved=true

# Zimanje detali za daden termin - GEt
  http://localhost:5000/api/Appointment/GetAppointmentDetails?appointmentId=8
  
