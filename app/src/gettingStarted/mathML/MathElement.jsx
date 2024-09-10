import React from "react";

const mathMLTutorial = () => {
    return (
        <>
            <h3>MathML Tutorial</h3>
            <div>
                Detta är ett bråk:
                <math>
                    <mfrac>
                        <mn>1</mn>
                        <mn>4</mn>
                    </mfrac>
                </math>
                <br />
                <br />
                <math>
                    <mfrac>
                        <mn>1</mn>
                        <mn>2</mn>
                    </mfrac>
                    <mo>+</mo>
                    <mfrac>
                        <mn>2</mn>
                        <mn>3</mn>
                    </mfrac>
                    <mo>=</mo>
                    <mfrac>
                        <mn>(3 + 4)</mn>
                        <mn>6</mn>
                    </mfrac>
                    <mo>=</mo>
                    <mfrac>
                        <mn>7</mn>
                        <mn>6</mn>
                    </mfrac>
                    <mo>=</mo>
                    <mo>1</mo>
                    <mfrac>
                        <mn>1</mn>
                        <mn>6</mn>
                    </mfrac>
                </math>
            </div>
        </>
    );
}

export default mathMLTutorial;