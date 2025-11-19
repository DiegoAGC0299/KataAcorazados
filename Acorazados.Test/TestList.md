- [x] Si agrego un cañonero con la coordenada 1,1, debe existir el cañonero en la coordenada 1,1.
- [x] Si agrego destructor con la coordenada 1,2 en la posición vertical, debe existir destructor en la coordenada 1,2 1,3 y 1,4
- [x] Si agrego destructor con la coordenada 1,2 en la posición horizontal, debe existir destructor en la coordenada 1,2 2,2 y 3,2
- [x] Si agrego portaviones con la coordenada 1,3 en la posición horizontal, debe existir portaviones en la coordenada 1,3 2,3 3,3 y 4,3
- [x] Si no hay barcos en el tablero, recibo un disparo con coordenada 1,1, debe asignar 'o' en la coordenada y retornar el mensaje 'Agua'
- [x] Si hay un destructor en el tablero con coordenada inicial 1,2, recibo un disparo con coordenada 1,2, debe asignar 'x' en la primera coordenada y mostrar en mensaje 'Tiro exitoso'
- [x] Si hay un destructor en el tablero con coordenada inicial 1,2, recibo dos disparos con coordenadas 1,2 y 2,2, debe asignar 'x' en la segunda coordenada y mostrar en mensaje 'Tiro exitoso'
- [x] Si hay un destructor en el tablero, recibo tres disparos con coordenadas 1,2 2,2 y 3,2, debe mostrar en mensaje del tercer disparo 'Barco hundido' y asignar 'X' en cada coordenada del barco.

#Casos de borde
- [] Si agrego portaviones con la coordenada 1,3 en la posición vertical, debe existir portaviones en la coordenada 1,3 1,4 1,5 y 1,6
- [] Si agrego dos cañoneros con la coordenada 1,1. el segundo debe arrojar excepción.