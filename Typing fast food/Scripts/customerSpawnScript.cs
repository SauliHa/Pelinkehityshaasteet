using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerSpawnScript : MonoBehaviour
{
    public GameObject customer1;
    public GameObject customer2;
    public GameObject customer3;
    public GameObject customer4;

    public void createCustomer()
    {
        GameObject randomCustomer;
        int customerNumber = Random.Range(1, 5);
        switch (customerNumber)
        {
            case 1: 
                randomCustomer = customer1;
                break;
            case 2:
                randomCustomer = customer2;
                break;
            case 3:
                randomCustomer = customer3;
                break;
            case 4:
                randomCustomer = customer4;
                break;
            default:
                randomCustomer = customer1;
                break;
        }
        GameObject newCustomer = Instantiate(randomCustomer, transform.position, transform.rotation) as GameObject;
    }
}
