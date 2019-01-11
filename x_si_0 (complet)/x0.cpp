#include<iostream>
#include<stdio.h>
#include<conio.h>							//includerea bibliotecilor
#define clrscr() (system("CLS"))			//definirea functiei clrscr()

using namespace std;

int verificare(char a[3][3], int r);
int r1,r2,tura=0;
int tabel(char a[3][3]);
int verificare_2(char a[3][3]);				//declarare subprograme
int main()
{
	int r,z,g,k,i,j;						
	char a[3][3],l='D';						//declarare si initializari variabile 				
	do
	{
		r=0;
		if(tura%2==0)
			z=0;
		else
			z=1;
		for(i=0;i<3;i++)
			for(j=0;j<3;j++)
				a[i][j]=' ';				//tabelul va fi gol
		r=tabel(a);							//r ia valoarea returnata de "tabel"
		while(r==0)
		{
			k=1;
			while(k!=0)
			{
				if(z%2==0)
					cout<<endl<<"Introduceti pozitia (Jucatorul 1): ";				//se introduc pozitiile dorite
				else
					cout<<endl<<"Introduceti pozitia (Jucatorul 2): ";
				cin>>g;
				if(g<1||g>9)
				{
					cout<<"Numarul trebuie sa fie de la 1 la 9 (inclusiv)!"<<endl;		//eroare de introducere a numarului
					k=1;
				}
			else
				{
					if((a[(g-1)/3][(g-1)%3]=='x')||(a[(g-1)/3][(g-1)%3]=='o'))
					{
						cout<<"Spatiul este deja umplut!"<<endl;						//eroare spatiu umplut
						k=1;
					}
				else
					k=0;
				}
			}	
		if(z%2==0)							//complectare cu x sau cu 0
			a[(g-1)/3][(g-1)%3]='x';
		else
			a[(g-1)/3][(g-1)%3]='o';
		clrscr();
		r=tabel(a);
		z++;
		}
	if(r==1)										//determinare castigator
	{
		cout<<"Jucatorul 1 a castigat"<<endl<<endl;
		r1++;
	}
	if(r==2)
	{
		cout<<"Jucatorul 2 a castigat"<<endl<<endl;
		r2++;
	}
	if(r==3)
		cout<<"Niciun jucator nu a castigat"<<endl<<endl;
	if(r)
	{
		cout<<"-----SCOR-----"<<endl<<"Jucatorul 1 :"<<r1<<endl<<"Jucatorul 2 :"<<r2<<endl<<endl;		//afisare scor
		cout<<"Vreti sa rejucati? \n Apasa tasta 'd'"<<endl;cin>>l;
		if(l!=0)	
			tura++;
		clrscr();
	}
	}while (l=='d');
}

int verificare(char a[3][3], int r)						//cautare castigator
{
	if((a[0][0]=='x')&&(a[1][1]=='x')&&(a[2][2]=='x'))
		r=1;
	if((a[0][0]=='x')&&(a[0][1]=='x')&&(a[0][2]=='x'))
		r=1;
	if((a[0][0]=='x')&&(a[1][0]=='x')&&(a[2][0]=='x'))
		r=1;
	if((a[2][0]=='x')&&(a[2][1]=='x')&&(a[2][2]=='x'))
		r=1;
	if((a[1][0]=='x')&&(a[1][1]=='x')&&(a[1][2]=='x'))
		r=1;
	if((a[0][1]=='x')&&(a[1][1]=='x')&&(a[2][1]=='x'))
		r=1;
	if((a[0][2]=='x')&&(a[1][2]=='x')&&(a[2][2]=='x'))
		r=1;
	if((a[0][2]=='x')&&(a[1][1]=='x')&&(a[2][0]=='x'))
		r=1;
	if((a[0][0]=='o')&&(a[1][1]=='o')&&(a[2][2]=='o'))
		r=2;
	if((a[0][0]=='o')&&(a[0][1]=='o')&&(a[0][2]=='o'))
		r=2;
	if((a[0][0]=='o')&&(a[1][0]=='o')&&(a[2][0]=='o'))
		r=2;
	if((a[2][0]=='o')&&(a[2][1]=='o')&&(a[2][2]=='o'))
		r=2;
	if((a[1][0]=='o')&&(a[1][1]=='o')&&(a[1][2]=='o'))
		r=2;
	if((a[0][1]=='o')&&(a[1][1]=='o')&&(a[2][1]=='o'))
		r=2;
	if((a[0][2]=='o')&&(a[1][2]=='o')&&(a[2][2]=='o'))
		r=2;
	if((a[0][2]=='o')&&(a[1][1]=='o')&&(a[2][0]=='o'))
		r=2;
	return r;
}

int tabel(char a[3][3])							//creare (tabelmatrita)
{
	int i,j,r,k=1,p;
	cout<<"      X si 0"<<endl<<endl<<endl;
	for(i=0;i<3;i++)
	{
		p=k+3;
		for(j=0;j<3;j++)
			cout<<a[i][j]<<"|";
		cout<<"       |";
		for(j=k;j<p;j++)
			cout<<j<<"|";
		k=k+3;
	cout<<endl;
	cout<<"-|-|-         -|-|-"<<endl;
	}
	r=verificare_2(a);
	return r;
}

int verificare_2(char a[3][3])					//returnare rezultat joc
{
	int i,j,s,r;
	r=verificare(a,0);
	s=0;
	for(i=0;i<3;i++)
		for(j=0;j<3;j++)
		{
			if((a[i][j]=='x')||(a[i][j]=='o'))
			s++;
		}
	if(r!=1&&r!=2&&s==9)						//r=1 => p1 castigator
		return (3);								//r=2 => p2 castigator
	if(r==1|r==2)								//r=3 => remiza
		return r;
	return 0;
}