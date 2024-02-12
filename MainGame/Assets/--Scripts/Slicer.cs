using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    // Die LayerMask, die bestimmt, welche Objekte geschnitten werden sollen.
    public LayerMask sliceMask;
    // Ein Trigger, um das Schneiden auszulösen.
    public bool isTouched;
    // Die Kraft, mit der die geschnittenen Teile auseinander fliegen.
    public float cutForce = 2000;
    AudioManager audiomanager;

    // Wird jeden Frame aufgerufen.
    public void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            // Finde alle Objekte, die innerhalb einer Box um das Slicer-Objekt liegen.
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);

            // Iteriere durch jedes zu schneidende Objekt.
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                audiomanager.PlaySFX(audiomanager.juicySound);
                // Schneide das Objekt und erhalte die geschnittenen Teile.
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

                // Erstelle obere und untere Hälften des geschnittenen Objekts.
                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                // Setze die Position der geschnittenen Teile auf die Position des ursprünglichen Objekts.
                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                // Mache die geschnittenen Teile physikalisch.
                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                // Zerstöre das ursprüngliche Objekt.
                Destroy(objectToBeSliced.gameObject);
            }
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        // Füge ein Rigidbody-Komponente hinzu.
        Rigidbody rb = obj.AddComponent<Rigidbody>();
        // Füge ein MeshCollider-Komponente hinzu und setze es auf konkav, um die Form des Meshes zu berücksichtigen.
        MeshCollider collider = obj.AddComponent<MeshCollider>();
        collider.convex = true;
        // Füge eine Explosionkraft hinzu, um die geschnittenen Teile auseinander zu treiben.
        rb.AddExplosionForce(cutForce, obj.transform.position, 1);
    }
    // Schneidet ein GameObject und gibt die geschnittenen Teile zurück.
    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
