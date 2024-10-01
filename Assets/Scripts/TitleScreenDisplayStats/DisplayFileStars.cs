using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFileStars : MonoBehaviour
{

    public Sprite star;
    public Sprite emptyStar;

    public Image f1s1;
    public Image f1s2;
    public Image f1s3;
    public Image f2s1;
    public Image f2s2;
    public Image f2s3;

    public void displayStars(bool file1Star1, bool file1Star2, bool file1Star3, bool file2Star1, bool file2Star2, bool file2Star3)
    {
        f1s1.sprite = (file1Star1 ? star : emptyStar);
        f1s2.sprite = (file1Star2 ? star : emptyStar);
        f1s3.sprite = (file1Star3 ? star : emptyStar);
        f2s1.sprite = (file2Star1 ? star : emptyStar);
        f2s2.sprite = (file2Star2 ? star : emptyStar);
        f2s3.sprite = (file2Star3 ? star : emptyStar);
    }
}
