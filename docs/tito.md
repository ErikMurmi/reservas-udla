Métodos:

# Usuarios

- registerUser
	Recibe: información del usuario.
		Un JSON: --El id es dado en la base de datos
            Email: mail@mail.com
			Password: ??? Que características debe tener?
			Nombre: ??? Alguna validación para esto?
			ID_BANNER: AXXXXXXXX
			Carrera: ??? Esto será un select? Lo de reduced significa tipo SW -> Software?
	Respuesta: 
		OK 200: si se registró el usuario correctamente
		BAD REQUEST 400: el usuario ya se encuentra registrado
- deleteUser
	Recibe: id del usuario, y debe haber una validación de pormedio ???
		id: número de id del usuario, que debe ser previamente obtenido en el front???
	Respuesta:
		OK 200: si se eliminó el usuario correctamente
		Bad Request 400: Si el usuario no existe
- updateUser
	Recibe: id del usuario
		Un JSON:
            Id: número entero o debería ser más bien un tipo session ???
			Email: mail@mail.com
			Password: ??? Que características debe tener?
			Nombre: ??? Alguna validación para esto?
			ID_BANNER: AXXXXXXXX
			Carrera: ??? Esto será un select? Lo de reduced significa tipo SW -> Software?
	Respuesta: 
		OK 200 si se actualizó el usuario correctamente
		Bad Request 400: si no se logró actualizar o no existe
- getUser
	Recibe:
		
	Respuesta:
		OK 200 + JSON:
			ID: un incremental
            Email: mail@mail.com
			Nombre: ??? Alguna validación para esto?
			ID_BANNER: AXXXXXXXX
			Carrera: ??? Esto será un select? Lo de reduced significa tipo SW -> Software?
- getSession ??? 
	Recibe: id del usuario + contraseña ??? 
	Respuesta: 
		OK 200 + debería ser algo de la sesión o un null si no hay el usuario???
		BAD REQUEST: algo salió mal :v


# Cancha

addField
	Recibe: información del field a añadir
	Respuesta: OK 200 si se añadió correctamente, 
updateField:
	Recibe:
	Respuesta: , posibles errores:
deleteField:
	Recibe:
	Respuesta: , posibles errores:
getField:
	Recibe:
	Respuesta: , posibles errores:
getAllFields:
	Recibe:
	Respuesta: , posibles errores:


# Solicitud

addRequest:
	Recibe:
	Respuesta: , posibles errores:
getRequest:
	Recibe:
	Respuesta: , posibles errores:
getRequestsFrom:
	Recibe:
	Respuesta: , posibles errores:
getAllRequests:
	Recibe:
	Respuesta: , posibles errores:
deleteRequest:
	Recibe:
	Respuesta: , posibles errores:
deleteAllFrom:
	Recibe:
	Respuesta: , posibles errores:
aproveRequest:
	Recibe:
	Respuesta: , posibles errores:
denieRequest:
	Detalle:
	Recibe:
	Respuesta: , posibles errores:


# Reserva

getBooking:
	Detalle:
	Recibe:
	Respuesta: , posibles errores:
getAllBookings:
	Detalle:
	Recibe:
	Respuesta: , posibles errores:
deleteBooking:
	Detalle:
	Recibe:
	Respuesta: , posibles errores:
updateBooking:
	Detalle:
	Recibe:
	Respuesta: , posibles errores:
addBooking:
	Detalle:
	Recibe:
	Respuesta: , posibles errores:


# Dudas:

Como vamos a hacer para que no se permita ingresar deportes que sean iguales bajo nombres distintos? Desde interfaz? Hay que ponerlo en algun lado?
el campus no debería tener también un constraint? O está pensado para que sea un texto? Porque ahí como se estandarizaría?

Cómo manejar sesiones?

En el tema de los bookings va a quedar un historial o eso en cuanto pase fecha se va a ir borrando? Eso nos corresponde a nosotros?

La info viene validada del front? Que validaciones debo hacer en el back?

La app es solo para estudiantes/docentes? Externos no se puede? Como vamos a validar el IDBanner

El id debe ser autoincremental?