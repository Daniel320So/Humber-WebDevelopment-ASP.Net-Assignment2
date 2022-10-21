# README

This respository is for Assignment 2 on HTTP 5112 - ASP.Net. The student id is N01537612.

Please follow below steps to test the assignment2

## 1. Run the Server on local host
    Open the project ./Assignment2.sln in Visual Studio
	Start up the controllers in ./Assignment2/Controllers

## 2. Test J1 (2006) - Menu

```bash
    curl http://localhost:57439/api/J1/Menu/4/4/4/4
    curl http://localhost:57439/api/J1/Menu/1/2/3/4
```
The expected outputs are

```bash
0
691
```

## 3. Test J2 (2006) - Dice Game

```bash
    curl http://localhost:57439/api/J2/DiceGame/6/8
    curl http://localhost:57439/api/J2/DiceGame/12/4
    curl http://localhost:57439/api/J2/DiceGame/3/3
    curl http://localhost:57439/api/J2/DiceGame/5/5
```
The expected outputs are

```bash
There are 5 ways to get the sum 10.
There are 4 ways to get the sum 10.
There are 0 ways to get the sum 10.
There is 1 ways to get the sum 10.
```

## 4. Test J4 (2022) - Good Groups

```bash
    curl http://localhost:57439/api/J4/GoodGroups/1/A%20B/1/A%20C/1/A%20C%20D
    curl http://localhost:57439/api/J4/GoodGroups/0/%20/0/%20/1/A%20C%20D
    curl http://localhost:57439/api/J4/GoodGroups/1/ELODIE%20CHI/0/%20/2/DWAYNE%20BEN%20ANJALI%20CHI%20FRANCOIS%20ELODIE
    curl http://localhost:57439/api/J4/GoodGroups/3/A%20B%20G%20L%20J%20K/2/D%20F%20D%20G/4/A%20C%20G%20B%20D%20F%20E%20H%20I%20J%20K%20L
```

The expected outputs are

```bash
2
0
0
3
```