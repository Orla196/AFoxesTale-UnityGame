using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;

public class AuthManager : MonoBehaviour
{
    public Text _logText;
    public Button signInBtn, signUpBtn;
    public InputField emailLogIn, passwordLogIn;
    public InputField emailSignUp, passwordSignUp;

    //public auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

    
    // Start is called before the first frame update
    public virtual void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        var dependencyStatus = task.Result;
        if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp,
            // where app is a Firebase.FirebaseApp property of your application class.
            // app = Firebase.FirebaseApp.DefaultInstance;

            // Set a flag here to indicate whether Firebase is ready to use by your app.
        } else {
            UnityEngine.Debug.LogError(System.String.Format(
            "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            // Firebase Unity SDK is not safe to use here.
        }
        });
    }
  

    public void OnClickSignUp() {
        Firebase.Auth.FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailSignUp.text, passwordSignUp.text).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            //logText.text = 'Sign up failed';
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            //logText.text = task.Exception.ToString();
            return;
        }

        // Firebase user has been created.
        Firebase.Auth.AuthResult result = task.Result;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            result.User.DisplayName, result.User.UserId);
        });
    }

    public void OnClickSignIn() {
        Firebase.Auth.FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailLogIn.text, passwordLogIn.text).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            //logText.text = 'Sign in cancelled';
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            // logText.text = task.Exception.ToString();
            return;
        }

        Firebase.Auth.AuthResult result = task.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})",
            result.User.DisplayName, result.User.UserId);
        });
    }

}
