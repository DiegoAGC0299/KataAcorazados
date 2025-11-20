- [x] Si agrego un cañonero con la coordenada 1,1, debe existir el cañonero en la coordenada 1,1.
- [x] Si agrego destructor con la coordenada 1,2 en la posición vertical, debe existir destructor en la coordenada 1,2 1,3 y 1,4
- [x] Si agrego destructor con la coordenada 1,2 en la posición horizontal, debe existir destructor en la coordenada 1,2 2,2 y 3,2
- [x] Si agrego portaviones con la coordenada 1,3 en la posición horizontal, debe existir portaviones en la coordenada 1,3 2,3 3,3 y 4,3
- [x] Si no hay barcos en el tablero, recibo un disparo con coordenada 1,1, debe asignar 'o' en la coordenada y retornar el mensaje 'Agua'
- [x] Si hay un destructor en el tablero con coordenada inicial 1,2, recibo un disparo con coordenada 1,2, debe asignar 'x' en la primera coordenada y mostrar en mensaje 'Tiro exitoso'
- [x] Si hay un destructor en el tablero con coordenada inicial 1,2, recibo dos disparos con coordenadas 1,2 y 2,2, debe asignar 'x' en la segunda coordenada y mostrar en mensaje 'Tiro exitoso'
- [x] Si hay un destructor en el tablero, recibo tres disparos con coordenadas 1,2 2,2 y 3,2, debe mostrar en mensaje del tercer disparo 'Barco hundido' y asignar 'X' en cada coordenada del barco.
- [x] Si hay un cañonero en el tablero, recibo un disparo con coordenadas 1,2 y hay coincidencia, debe mostrar en mensaje del tiro 'Barco hundido' y asignar 'X' a la coordenada del barco.
- [x] Si hay un portaaviones en el tablero, recibo cuatro disparos y hay coincidencia, debe mostrar en mensaje del ultimo tiro 'Barco hundido' y asignar 'X' a la coordenadas del barco.
- [x] Si agrego dos portaaviones debe arrojar excepcion 
- [x] Si agrego tres destructores debe arrojar excepcion 
- [x] Si agrego cinco cañoneros debe arrojar excepcion
- [x] Si agrego dos cañoneros en la coordenada 1_1 debe arrojar excepción

#Jugadores
- [x] Si agrego un jugador, debe existir un jugador con un tablero
- [x] Si agrego más de dos jugadores, debe lanzar excepción

#Informe del tablero
- [] Si imprimo el informe de la partida y el juego no ha sido finalizado, debe lanzar excepción.
- [] Si finaliza la partida y el jugador 1 le hicieron dos disparos, debe en el informe, el total de disparos del jugador 1 ser 2.