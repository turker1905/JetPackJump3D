using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRB;
    [SerializeField] Animator _Playeranim;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _runSpeed;
   public static int _jumpCount = 0;
    bool _startGame;
    float _time;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] Text _ScorText,_bestScorText;
    



    private void Awake()
    {
        _jumpCount = 0;
        Time.timeScale = 1;
        
    }

    private void Start()
    {
        _bestScorText.text =  "Best Scor = "+PlayerPrefs.GetInt("bestscor").ToString();
    }

    private void FixedUpdate()
    {
        if (_startGame)
        {
            _playerTransform.Translate(transform.forward * Time.deltaTime * _runSpeed);
            _Playeranim.SetBool("__isRun",true);
        }
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startGame && OnGroundCheck.IsOnGround == true && _jumpCount <= 2)
            {
                _time = 0;
                _playerRB.AddForce(Vector3.up * 500);
                _Playeranim.SetTrigger("__isJump");
                _Playeranim.SetBool("__isRun", false);
                _jumpCount++;

            }

            if (_jumpCount == 3)
            {
                _playerRB.AddForce(Vector3.up * 1000);
                _jumpCount++;
                //Jetpack Kodları


            }

            _startGame = true;

        }

    



        if (_jumpCount>=1 && OnGroundCheck.IsOnGround == true)
        {
            _time += Time.deltaTime;
            if (_time>=2f)
            {
                _runSpeed = 2f;
                _Playeranim.SetBool("__isDie",true);
            }


            if (_time >= 4.5f)
            {

                int scor = (int)(_playerTransform.position.z);

                _ScorText.text = "Score = " + scor.ToString("##.") + "m";
                _gameOverPanel.SetActive(true);

                if (PlayerPrefs.GetInt("bestscor")<= scor)
                {
                    PlayerPrefs.SetInt("bestscore",scor);
                }
               

                Time.timeScale = 0;
            }

        }

    }



}
