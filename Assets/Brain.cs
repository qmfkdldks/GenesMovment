
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (SimpleCharacterControl))]
public class Brain : MonoBehaviour
{
    public int DNALength = 1;
    public float timeAlive;
    public DNA dna;

    private SimpleCharacterControl m_Character;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        dna = new DNA(DNALength, 6);
        m_Character = GetComponent<SimpleCharacterControl>();
        timeAlive = 0;
        alive = true;
    }

    private void FixedUpdate()
    {
        float h = 0;
        float v = 0;
        bool crouch = false;
        if(dna.GetGene(0) == 0) v = 1;
        else if(dna.GetGene(0) == 1) v = -1;
        else if(dna.GetGene(0) == 2) h = -1;
        else if(dna.GetGene(0) == 3) h = 1;
        else if(dna.GetGene(0) == 4) m_Jump = true;
        else if(dna.GetGene(0) == 5) crouch = true;
    
        m_Character.Move(v, h, m_Jump);
        m_Jump = false;
        if(alive)
            timeAlive += Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
