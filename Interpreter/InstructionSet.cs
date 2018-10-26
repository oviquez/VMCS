using System;
using System.Collections.Generic;
using System.Collections;
using AlmacenNameSpace;

namespace InstructionsNameSpace{
    class InstructionSet
    {   
        private List<KeyValuePair<string, dynamic>> instSet {get; set;}
        private Almacen almacenGlobal {get; set;} //se define un almacen global para manejo de variables globales y referencias a métodos
        private Almacen almacenLocal {get; set;} //se define un almacén local para variables locales *** PUEDE QUE SE REQUIERA UNO POR CADA CONTEXTO PERO ESO DEBE DEFINIRSE ***
        //private Pila pilaExprs {get; set;}
        private int actualInstrIndex {get; set;}
        
        public InstructionSet(){
            instSet = new List<KeyValuePair<string,dynamic>>() ;
            almacenGlobal = new Almacen("Global");
            almacenLocal = new Almacen("Local");
            actualInstrIndex=0;
            test();
        }

        public void addInst(string inst, dynamic param){
            instSet.Add(new KeyValuePair<string, dynamic>(inst,param));
        }

        public void runPUSH_LOCAL_I(string name){ //podría recibir el almacen del contexto en caso de que se requiera
            //declara el elemento "name" en el almacen LOCAL con valor por defecto 0
            almacenLocal.setValue(name,0);
        }
        public void runPUSH_LOCAL_C(string name){ //podría recibir el almacen del contexto en caso de que se requiera
            //declara el elemento "name" en el almacen LOCAL con valor por defecto ''
            almacenLocal.setValue(name,' ');
        }
        public void runPUSH_GLOBAL_I(string name){
            //declara el elemento "name" en el almacen GLOBAL con valor por defecto 0
            almacenGlobal.setValue(name,0);
        }
        public void runPUSH_GLOBAL_C(string name){
            //declara el elemento "name" en el almacen GLOBAL con valor por defecto ''
            almacenLocal.setValue(name,' ');
        }
        public void runDEF(string name){

        }
        // SI ALGUIEN SABE PORQUE DA ESTE ERROR CON ESTOS DOS MÉTODOS, FAVOR CORREGIR!!!
        /* public void runLOAD_CONST(int const){
            //carga en la pila el valor entero contenido en "const"
            int x =0;
        }
        public void runLOAD_CONST(char const){
            //carga en la pila el valor char contenido en "const"
        }*/
        public void runLOAD_FAST(string varname){ //podría recibir el almacen del contexto en caso de que se requiera
            //busca en el almacén LOCAL el valor asociado a "varname" y lo inserta en la pila
            almacenLocal.getValue(varname); //EL GET VALUE DEBE DEVOLVER UN VALOR PARA PODERLO CARGAR A LA PILA
            //pilaExprs.push(val);
        }
        public void runSTORE_FAST(string varname){ //podría recibir el almacen del contexto en caso de que se requiera
            //almacena el contenido del tope de la pila en el almacén LOCAL para la variable "varname"
            dynamic tope=0;
            //tope == pilaExprs.pop(); //debe sacar el elemento de la pila y devolver su valor
            almacenLocal.setValue(varname,tope);
        }
        public void runSTORE_GLOBAL(string varname){
            //almacena el contenido del tope de la pila en el almacén GLOBAL para la variable "varname"
            dynamic tope=0;
            //tope == pilaExprs.pop(); //debe sacar el elemento de la pila y devolver su valor
            almacenLocal.setValue(varname,tope);
        }
        public void runLOAD_GLOBAL(string varname){
            //busca en el almacén GLOBAL el valor asociado a "varname" y lo inserta en la pila
            almacenGlobal.getValue(varname); //EL GET VALUE DEBE DEVOLVER UN VALOR PARA PODERLO CARGAR A LA PILA
            //pilaExprs.push(val);
        }
        public void runCALL_FUNCTION(int numparams){
            //lo referente a call function
        }
        public void runRETURN_VALUE(){
            //lo referente a return value
        }
        public void runEND(){
            //acaba la corrida y limpia/elimina las estructuras según sea el caso
        }
        public void runCOMPARE_OP(string op){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores de los operandos son del mismo tipo, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runBINARY_SUBSTRACT(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runBINARY_ADD(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runBINARY_MULTIPLY(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runBINARY_DIVIDE(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runBINARY_AND(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runBINARY_OR(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        //PUEDE QUE ESTA NO SE OCUPE
        public void runBINARY_MODULO(){
            //obtiene dos operandos de la pila, opera según el operador y finalmente inserta el resultados de la operación en la pila
            //se asume que los valores son enteros, si no, se cae feo pero así debe ser... no hay mensajes de error
        }
        public void runJUMP_ABSOLUTE(int target){
            //cambia el indice de la línea actual en ejecución a la indicada por "target"
        }
        public void runJUMP_IF_TRUE(int target){
            //cambia el indice de la línea actual en ejecución a la indicada por "target" en caso de que el tope de la pila sea TRUE
        }
        public void runJUMP_IF_FALSE(int target){
            //cambia el indice de la línea actual en ejecución a la indicada por "target" en caso de que el tope de la pila sea FALSE
        }

        //método principal para correr todas las instrucciones de la lista... Este método debe recorrer la lista solo para agregar en el almacen global 
        //las variables y métodos que hayan y cuando se encuentre el Main, este método si debe ejecutarse línea por línea porque es el punto de inicio
        //del programa
        public void run(){
            while (actualInstrIndex <= instSet.Count-1)
            {
                if (instSet[actualInstrIndex].Key.Equals("PUSH_GLOBAL_I")||
                instSet[actualInstrIndex].Key.Equals("PUSH_GLOBAL_C")||
                instSet[actualInstrIndex].Key.Equals("DEF")){
                    switch(instSet[actualInstrIndex].Key){
                        case "PUSH_GLOBAL_I": 
                        case "PUSH_GLOBAL_C": 
                            almacenGlobal.setValue(instSet[actualInstrIndex].Key,instSet[actualInstrIndex].Value);                            
                            break;
                        case "DEF": 
                            if (instSet[actualInstrIndex].Value.Equals("Main")){
                                actualInstrIndex++; //se incrementa para que contenga la primera línea de código del Main
                                runMain();
                                break; //espero que sea break del ciclo y no del switch
                            }
                            break;
                        

                    //debería llamarse a runXXXXX de cada instrucción para toda la lista en orden ascendente
                    }
                    Console.WriteLine(instSet[actualInstrIndex].Key + " " + instSet[actualInstrIndex].Value);
                }
                actualInstrIndex++;
            }
        }

        public void runMain(){
            while (actualInstrIndex <= instSet.Count-1)
            {
                switch(instSet[actualInstrIndex].Key){
                        case "PUSH_LOCAL_I":
                            runPUSH_LOCAL_I(instSet[actualInstrIndex].Value);
                            break;
                        case "PUSH_LOCAL_C":
                            runPUSH_LOCAL_C(instSet[actualInstrIndex].Value);
                            break;
                        case "PUSH_GLOBAL_I":
                            runPUSH_GLOBAL_I(instSet[actualInstrIndex].Value);
                            break;
                        case "PUSH_GLOBAL_C":
                            runPUSH_GLOBAL_C(instSet[actualInstrIndex].Value);
                            break;
                        case "LOAD_CONST":
                            //asumiendo que el polimorfismo va a funcionar
                            //runLOAD_CONST(instSet[actualInstrIndex].Value);
                            break;
                        case "LOAD_FAST":
                            runLOAD_FAST(instSet[actualInstrIndex].Value);
                            break;
                        case "STORE_FAST":
                            runSTORE_FAST(instSet[actualInstrIndex].Value);
                            break;
                        case "STORE_GLOBAL":
                            runSTORE_GLOBAL(instSet[actualInstrIndex].Value);
                            break;
                        case "LOAD_GLOBAL":
                            runLOAD_GLOBAL(instSet[actualInstrIndex].Value);
                            break;
                        case "CALL_FUNCTION":
                            runCALL_FUNCTION(instSet[actualInstrIndex].Value);
                            break;
                        case "RETURN_VALUE":
                            runRETURN_VALUE();
                            break;
                        case "END":
                            runEND();
                            break;
                        case "COMPARE_OP":
                            runCOMPARE_OP(instSet[actualInstrIndex].Value);
                            break;
                        case "BINARY_SUBSTRACT":
                            runBINARY_SUBSTRACT();
                            break;
                        case "BINARY_ADD":
                            runBINARY_ADD();
                            break;
                        case "BINARY_MULTIPLY":
                            runBINARY_MULTIPLY();
                            break;
                        case "BINARY_DIVIDE":
                            runBINARY_DIVIDE();
                            break;
                        case "BINARY_AND":
                            runBINARY_AND();
                            break;
                        case "BINARY_OR":
                            runBINARY_OR();
                            break;
                        case "BINARY_MODULO":
                            runBINARY_MODULO();
                            break;
                        case "JUMP_ABSOLUTE":
                            runJUMP_ABSOLUTE(instSet[actualInstrIndex].Value);
                            break;
                        case "JUMP_IF_TRUE":
                            runJUMP_IF_TRUE(instSet[actualInstrIndex].Value);
                            break;
                        case "JUMP_IF_FALSE":
                            runJUMP_IF_FALSE(instSet[actualInstrIndex].Value);
                            break;
                actualInstrIndex++;
                Console.WriteLine(instSet[actualInstrIndex].Key + " " + instSet[actualInstrIndex].Value);
                } 
            }
        }

        public void test(){
            addInst("PUSH_GLOBAL_I","n");
            addInst("PUSH_GLOBAL_C","res");
            addInst("LOAD_CONST",10);
            addInst("STORE_GLOBAL","n");
            addInst("LOAD_CONST",'a');
            addInst("STORE_GLOBAL","res");
        }
    }
}