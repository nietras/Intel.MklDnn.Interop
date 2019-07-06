 
 
 

#pragma once
#include <ippdefs.h>

namespace Intel.MklDnn
{
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_version_t
    {
    public:
        int    major;
        int    minor;
        int    patch;
        const char *hash;
    };
    
    public enum class Nmkldnn_status_t
    {
        /// The operation was successful
        _success = 0,
        /// The operation failed due to an out-of-memory condition
        _out_of_memory = 1,
        /// The operation failed because of incorrect function arguments
        _invalid_arguments = 2,
        /// The operation failed because requested functionality is not implemented
        _unimplemented = 3,
        /// Primitive iterator passed over last primitive descriptor
        _iterator_ends = 4,
        /// Primitive or engine failed on execution
        _runtime_error = 5,
        /// Queried element is not required for given primitive
        _not_required = 6,
    };
    
    public enum class Nmkldnn_data_type_t
    {
        /// Undefined data type, used for empty memory descriptors.
        _data_type_undef = 0,
        /// 16-bit/half-precision floating point.
        _f16 = 1,
        /// non-standard 16-bit (bfloat16 w/ 7 bit mantissa) floating point.
        _bf16 = 2,
        /// 32-bit/single-precision floating point.
        _f32 = 3,
        /// 32-bit signed integer.
        _s32 = 4,
        /// 8-bit signed integer.
        _s8 = 5,
        /// 8-bit unsigned integer.
        _u8 = 6,
    };
    
    public enum class Nmkldnn_format_kind_t
    {
        /// Undefined memory format kind, used for empty memory descriptors.
        _format_kind_undef = 0,
        /// Unspecified format kind.
        /// The primitive selects a format automatically.
        _format_kind_any,
        /// A tensor in a generic format described by the stride and blocking
        /// values in each dimension. See @ref mkldnn_blocking_desc_t for more
        /// information.
        _blocked,
        /// Weights format used in 8bit Winograd convolution
        _format_kind_wino,
        /// Packed weights format used in RNN
        _format_kind_rnn_packed,
    };
    
    public enum class Nmkldnn_format_tag_t
    {
        /// Undefined memory format tag
        _format_tag_undef = 0,
        /// Undefined memory format tag.
        /// The primitive selects a format automatically.
        _format_tag_any,
        // Semantic agnostic section
        // The physical order of dimensions is defined by the permutation of the
        // characters, assuming that ab..z defines the natural order.
        // Plain formats
        _a, ///< plain 1D tensor
        _ab, ///< plain 2D tensor
        _abc, ///< plain 3D tensor
        _abcd, ///< plain 4D tensor
        _abcde, ///< plain 5D tensor
        _abcdef, ///< plain 6D tensor
        // Permuted plain formats
        _abdec, ///< permuted 5D tensor
        _acb, ///< permuted 3D tensor
        _acbde, ///< permuted 5D tensor
        _acdb, ///< permuted 4D tensor
        _acdeb, ///< permuted 5D tensor
        _ba, ///< permuted 2D tensor
        _bac, ///< permuted 3D tensor
        _bacd, ///< permuted 4D tensor
        _bca, ///< permuted 3D tensor
        _bcda, ///< permuted 4D tensor
        _bcdea, ///< permuted 5D tensor
        _cba, ///< permuted 3D tensor
        _cdba, ///< permuted 4D tensor
        _cdeba, ///< permuted 5D tensor
        _decab, ///< permuted 5D tensor
        // Opaque blocked formats
        _Abc16a,
        _ABc16a16b,
        /// 3D tensor blocked by 2nd dimension with block size 16
        _aBc16b,
        _ABc16b16a,
        _Abc4a,
        /// 3D tensor blocked by 2nd dimension with block size 4
        _aBc4b,
        _ABc4b16a4b,
        _ABc4b4a,
        _ABc8a16b2a,
        _ABc8a8b,
        /// 3D tensor blocked by 2nd dimension with block size 8
        _aBc8b,
        _ABc8b16a2b,
        _BAc8a16b2a,
        _ABc8b8a,
        _Abcd16a,
        _ABcd16a16b,
        _ABcd32a32b,
        /// 4D tensor blocked by 2nd dimension with block size 16
        _aBcd16b,
        _ABcd16b16a,
        _aBCd16b16c,
        _aBCd16c16b,
        _Abcd4a,
        /// 4D tensor blocked by 2nd dimension with block size 4
        _aBcd4b,
        _ABcd4b16a4b,
        _ABcd4b4a,
        _aBCd4c16b4c,
        _aBCd4c4b,
        _ABcd8a16b2a,
        _ABcd8a8b,
        /// 4D tensor blocked by 2nd dimension with block size 8
        _aBcd8b,
        _ABcd8b16a2b,
        _aBCd8b16c2b,
        _BAcd8a16b2a,
        /// 4D tensor blocked by 1st and 2nd dimension with block size 8
        _ABcd8b8a,
        _aBCd8b8c,
        _aBCd8c16b2c,
        _ABcde8a16b2a,
        _aCBd8b16c2b,
        _aBCd8c8b,
        _Abcde16a,
        _ABcde16a16b,
        _BAcde8a16b2a,
        /// 5D tensor blocked by 2nd dimension with block size 16
        _aBcde16b,
        _ABcde16b16a,
        _aBCde16b16c,
        _aBCde16c16b,
        _aBCde2c8b4c,
        _Abcde4a,
        /// 5D tensor blocked by 2nd dimension with block size 4
        _aBcde4b,
        _ABcde4b4a,
        _aBCde4b4c,
        _aBCde4c16b4c,
        _aBCde4c4b,
        _Abcde8a,
        _ABcde8a8b,
        _BAcde16b16a,
        /// 5D tensor blocked by 2nd dimension with block size 8
        _aBcde8b,
        _ABcde8b16a2b,
        _aBCde8b16c2b,
        _aCBde8b16c2b,
        _ABcde8b8a,
        _aBCde8b8c,
        _ABcd4a8b8a4b,
        _ABcd2a8b8a2b,
        _aBCde4b8c8b4c,
        _aBCde2b8c8b2c,
        _aBCde8c16b2c,
        _aBCde8c8b,
        /// 6D tensor blocked by 2nd dimension with block size 16
        _aBcdef16b,
        _aBCdef16b16c,
        _aBCdef16c16b,
        /// 6D tensor blocked by 2nd dimension with block size 4
        _aBcdef4b,
        _aBCdef4c4b,
        _aBCdef8b8c,
        _aBCdef8c16b2c,
        _aBCdef8b16c2b,
        _aCBdef8b16c2b,
        _aBCdef8c8b,
        _aBdc16b,
        _aBdc4b,
        _aBdc8b,
        _aBdec16b,
        _aBdec32b,
        _aBdec4b,
        _aBdec8b,
        _aBdefc16b,
        _aCBdef16c16b,
        _aBdefc4b,
        _aBdefc8b,
        _Abcdef16a,
        _Acb16a,
        _Acb4a,
        _Acb8a,
        _aCBd16b16c,
        _aCBd16c16b,
        _aCBde16b16c,
        _aCBde16c16b,
        _Acdb16a,
        _Acdb32a,
        _Acdb4a,
        _Acdb8a,
        _Acdeb16a,
        _Acdeb4a,
        _Acdeb8a,
        _BAc16a16b,
        _BAc16b16a,
        _BAcd16a16b,
        _BAcd16b16a,
        /// Just a sentinel, not real memory format tag. Must be changed after new
        /// format tag is added.
        _format_tag_last,
        // Aliases
        /// 1D tensor, an alias to #mkldnn_a
        _x = mkldnn_a,
        /// 2D CNN activations tensor, an alias to #mkldnn_ab
        _nc = mkldnn_ab,
        /// 2D CNN activations tensor, an alias to #mkldnn_ba
        _cn = mkldnn_ba,
        /// 3D CNN activations tensor, an alias to #mkldnn_abc
        _ncw = mkldnn_abc,
        /// 3D CNN activations tensor, an alias to #mkldnn_acb
        _nwc = mkldnn_acb,
        /// 4D CNN activations tensor, an alias to #mkldnn_abcd
        _nchw = mkldnn_abcd,
        /// 4D CNN activations tensor, an alias to #mkldnn_acdb
        _nhwc = mkldnn_acdb,
        /// 4D CNN activations tensor, an alias to #mkldnn_bcda
        _chwn = mkldnn_bcda,
        /// 5D CNN activations tensor, an alias to #mkldnn_abcde
        _ncdhw = mkldnn_abcde,
        /// 5D CNN activations tensor, an alias to #mkldnn_acdeb
        _ndhwc = mkldnn_acdeb,
        /// 2D CNN weights tensor, an alias to #mkldnn_ab
        _oi = mkldnn_ab,
        /// 2D CNN weights tensor, an alias to #mkldnn_ba
        _io = mkldnn_ba,
        /// 3D CNN weights tensor, an alias to #mkldnn_abc
        _oiw = mkldnn_abc,
        /// 3D CNN weights tensor, an alias to #mkldnn_acb
        _owi = mkldnn_acb,
        /// 3D CNN weights tensor, an alias to #mkldnn_cba
        _wio = mkldnn_cba,
        /// 3D CNN weights tensor, an alias to #mkldnn_bca
        _iwo = mkldnn_bca,
        /// 4D CNN weights tensor, an alias to #mkldnn_abcd
        _oihw = mkldnn_abcd,
        /// 4D CNN weights tensor, an alias to #mkldnn_cdba
        _hwio = mkldnn_cdba,
        /// 4D CNN weights tensor, an alias to #mkldnn_acdb
        _ohwi = mkldnn_acdb,
        /// 4D CNN weights tensor, an alias to #mkldnn_bcda
        _ihwo = mkldnn_bcda,
        /// 4D CNN weights tensor, an alias to #mkldnn_bacd
        _iohw = mkldnn_bacd,
        /// 5D CNN weights tensor, an alias to #mkldnn_abcde
        _oidhw = mkldnn_abcde,
        /// 5D CNN weights tensor, an alias to #mkldnn_cdeba
        _dhwio = mkldnn_cdeba,
        /// 5D CNN weights tensor, an alias to #mkldnn_acdeb
        _odhwi = mkldnn_acdeb,
        /// 5D CNN weights tensor, an alias to #mkldnn_bcdea
        _idhwo = mkldnn_bcdea,
        /// 4D CNN weights tensor (incl. groups), an alias to #mkldnn_abcd
        _goiw = mkldnn_abcd,
        /// 5D CNN weights tensor (incl. groups), an alias to #mkldnn_abcde
        _goihw = mkldnn_abcde,
        /// 5D CNN weights tensor (incl. groups), an alias to #mkldnn_decab
        _hwigo = mkldnn_decab,
        /// 5D CNN weights tensor (incl. groups), an alias to #mkldnn_acbde
        _giohw = mkldnn_acbde,
        /// 6D CNN weights tensor (incl. groups), an alias to #mkldnn_abcdef
        _goidhw = mkldnn_abcdef,
        /// 3D RNN data tensor in the format (seq_length, batch, input channels).
        _tnc = mkldnn_abc,
        /// 3D RNN data tensor in the format (batch, seq_length, input channels).
        _ntc = mkldnn_bac,
        /// 4D RNN states tensor in the format (num_layers, num_directions,
        /// batch, state channels).
        _ldnc = mkldnn_abcd,
        /// 5D RNN weights tensor in the format (num_layers, num_directions,
        ///  input_channels, num_gates, output_channels).
        ///
        ///  - For LSTM cells, the gates order is input, forget, candidate
        ///    and output gate.
        ///  - For GRU cells, the gates order is update, reset and output gate.
        _ldigo = mkldnn_abcde,
        /// 5D RNN weights tensor in the format (num_layers, num_directions,
        /// num_gates, output_channels, input_channels).
        ///
        ///  - For LSTM cells, the gates order is input, forget, candidate
        ///    and output gate.
        ///  - For GRU cells, the gates order is update, reset and output gate.
        _ldgoi = mkldnn_abdec,
        /// 4D RNN bias tensor in the format (num_layers, num_directions,
        /// num_gates, output_channels).
        ///
        ///  - For LSTM cells, the gates order is input, forget, candidate
        ///    and output gate.
        ///  - For GRU cells, the gates order is update, reset and output gate.
        _ldgo = mkldnn_abcd,
        // Opaque data types, are not to be used explicitly
        // data
        /// 5D CNN activations tensor blocked by channels with block size 16,
        /// an alias to #mkldnn_aBcde16b
        _nCdhw16c = mkldnn_aBcde16b,
        /// 5D CNN activations tensor blocked by channels with block size 4,
        /// an alias to #mkldnn_aBcde4b
        _nCdhw4c = mkldnn_aBcde4b,
        /// 5D CNN activations tensor blocked by channels with block size 8,
        /// an alias to #mkldnn_aBcde8b
        _nCdhw8c = mkldnn_aBcde8b,
        /// 4D CNN activations tensor blocked by channels with block size 16,
        /// an alias to #mkldnn_aBcd16b
        _nChw16c = mkldnn_aBcd16b,
        /// 4D CNN activations tensor blocked by channels with block size 4,
        /// an alias to #mkldnn_aBcd4b
        _nChw4c = mkldnn_aBcd4b,
        /// 4D CNN activations tensor blocked by channels with block size 8,
        /// an alias to #mkldnn_aBcd8b
        _nChw8c = mkldnn_aBcd8b,
        /// 3D CNN activations tensor blocked by channels with block size 16,
        /// an alias to #mkldnn_aBc16b
        _nCw16c = mkldnn_aBc16b,
        /// 3D CNN activations tensor blocked by channels with block size 4,
        /// an alias to #mkldnn_aBc4b
        _nCw4c = mkldnn_aBc4b,
        /// 3D CNN activations tensor blocked by channels with block size 8,
        /// an alias to #mkldnn_aBc8b
        _nCw8c = mkldnn_aBc8b,
        _NCw16n16c = mkldnn_ABc16a16b,
        _NCdhw16n16c = mkldnn_ABcde16a16b,
        _NChw16n16c = mkldnn_ABcd16a16b,
        _NChw32n32c = mkldnn_ABcd32a32b,
        // weights, 3D
        _IOw16o16i = mkldnn_BAc16a16b,
        _IOw16i16o = mkldnn_BAc16b16a,
        _OIw16i16o = mkldnn_ABc16b16a,
        _OIw16o16i = mkldnn_ABc16a16b,
        _Oiw16o = mkldnn_Abc16a,
        _OIw4i16o4i = mkldnn_ABc4b16a4b,
        _OIw4i4o = mkldnn_ABc4b4a,
        _Oiw4o = mkldnn_Abc4a,
        _OIw8i16o2i = mkldnn_ABc8b16a2b,
        _OIw8i8o = mkldnn_ABc8b8a,
        _OIw8o16i2o = mkldnn_ABc8a16b2a,
        _IOw8o16i2o = mkldnn_BAc8a16b2a,
        _OIw8o8i = mkldnn_ABc8a8b,
        _Owi16o = mkldnn_Acb16a,
        _Owi4o = mkldnn_Acb4a,
        _Owi8o = mkldnn_Acb8a,
        // weights, 4D
        _IOhw16i16o = mkldnn_BAcd16b16a,
        _IOhw16o16i = mkldnn_BAcd16a16b,
        _Ohwi16o = mkldnn_Acdb16a,
        _Ohwi32o = mkldnn_Acdb32a,
        _Ohwi4o = mkldnn_Acdb4a,
        _Ohwi8o = mkldnn_Acdb8a,
        _OIhw16i16o = mkldnn_ABcd16b16a,
        _OIhw16o16i = mkldnn_ABcd16a16b,
        _Oihw16o = mkldnn_Abcd16a,
        _OIhw4i16o4i = mkldnn_ABcd4b16a4b,
        _OIhw4i4o = mkldnn_ABcd4b4a,
        _Oihw4o = mkldnn_Abcd4a,
        _OIhw8i16o2i = mkldnn_ABcd8b16a2b,
        _OIhw8i8o = mkldnn_ABcd8b8a,
        _OIhw8o16i2o = mkldnn_ABcd8a16b2a,
        _IOhw8o16i2o = mkldnn_BAcd8a16b2a,
        _OIhw8o8i = mkldnn_ABcd8a8b,
        // weights, 5D
        _Odhwi16o = mkldnn_Acdeb16a,
        _Odhwi4o = mkldnn_Acdeb4a,
        _Odhwi8o = mkldnn_Acdeb8a,
        _OIdhw16i16o = mkldnn_ABcde16b16a,
        _OIdhw16o16i = mkldnn_ABcde16a16b,
        _Oidhw16o = mkldnn_Abcde16a,
        _OIdhw4i4o = mkldnn_ABcde4b4a,
        _Oidhw4o = mkldnn_Abcde4a,
        _OIdhw8i16o2i = mkldnn_ABcde8b16a2b,
        _OIdhw8i8o = mkldnn_ABcde8b8a,
        _OIdhw8o16i2o = mkldnn_ABcde8a16b2a,
        _IOdhw8o16i2o = mkldnn_BAcde8a16b2a,
        _OIdhw8o8i = mkldnn_ABcde8a8b,
        _IOdhw16i16o = mkldnn_BAcde16b16a,
        // weights w/ groups, 3D
        _Goiw16g = mkldnn_Abcd16a,
        _gIOw16o16i = mkldnn_aCBd16b16c,
        _gIOw16i16o = mkldnn_aCBd16c16b,
        _gOIw16i16o = mkldnn_aBCd16c16b,
        _gOIw16o16i = mkldnn_aBCd16b16c,
        _gOiw16o = mkldnn_aBcd16b,
        _gOIw4i16o4i = mkldnn_aBCd4c16b4c,
        _gOIw4i4o = mkldnn_aBCd4c4b,
        _gOiw4o = mkldnn_aBcd4b,
        _gOIw8i16o2i = mkldnn_aBCd8c16b2c,
        _gOIw8i8o = mkldnn_aBCd8c8b,
        _gOIw8o16i2o = mkldnn_aBCd8b16c2b,
        _gIOw8o16i2o = mkldnn_aCBd8b16c2b,
        _gOIw8o8i = mkldnn_aBCd8b8c,
        _gOwi16o = mkldnn_aBdc16b,
        _gOwi4o = mkldnn_aBdc4b,
        _gOwi8o = mkldnn_aBdc8b,
        // weights w/ groups, 4D
        _gIOhw16i16o = mkldnn_aCBde16c16b,
        _gIOhw16o16i = mkldnn_aCBde16b16c,
        _gOhwi16o = mkldnn_aBdec16b,
        _gOhwi32o = mkldnn_aBdec32b,
        _gOhwi4o = mkldnn_aBdec4b,
        _gOhwi8o = mkldnn_aBdec8b,
        _Goihw16g = mkldnn_Abcde16a,
        _gOIhw16i16o = mkldnn_aBCde16c16b,
        _gOIhw16o16i = mkldnn_aBCde16b16c,
        _gOihw16o = mkldnn_aBcde16b,
        _gOIhw2i8o4i = mkldnn_aBCde2c8b4c,
        _gOIhw4i16o4i = mkldnn_aBCde4c16b4c,
        _gOIhw4i4o = mkldnn_aBCde4c4b,
        _gOIhw4o4i = mkldnn_aBCde4b4c,
        _gOihw4o = mkldnn_aBcde4b,
        _Goihw8g = mkldnn_Abcde8a,
        _gOIhw8i16o2i = mkldnn_aBCde8c16b2c,
        _gOIhw8i8o = mkldnn_aBCde8c8b,
        _gOIhw8o16i2o = mkldnn_aBCde8b16c2b,
        _gIOhw8o16i2o = mkldnn_aCBde8b16c2b,
        _gOIhw8o8i = mkldnn_aBCde8b8c,
        _OIhw4o8i8o4i = mkldnn_ABcd4a8b8a4b,
        _OIhw2o8i8o2i = mkldnn_ABcd2a8b8a2b,
        _gOIhw4o8i8o4i = mkldnn_aBCde4b8c8b4c,
        _gOIhw2o8i8o2i = mkldnn_aBCde2b8c8b2c,
        // weights w/ groups, 6D
        _gIOdhw16i16o = mkldnn_aCBdef16c16b,
        _gOdhwi16o = mkldnn_aBdefc16b,
        _gOdhwi4o = mkldnn_aBdefc4b,
        _gOdhwi8o = mkldnn_aBdefc8b,
        _gOIdhw16i16o = mkldnn_aBCdef16c16b,
        _gOIdhw16o16i = mkldnn_aBCdef16b16c,
        _gOidhw16o = mkldnn_aBcdef16b,
        _gOIdhw4i4o = mkldnn_aBCdef4c4b,
        _gOidhw4o = mkldnn_aBcdef4b,
        _gOIdhw8i16o2i = mkldnn_aBCdef8c16b2c,
        _gOIdhw8i8o = mkldnn_aBCdef8c8b,
        _gOIdhw8o16i2o = mkldnn_aBCdef8b16c2b,
        _gIOdhw8o16i2o = mkldnn_aCBdef8b16c2b,
        _gOIdhw8o8i = mkldnn_aBCdef8b8c,
        _Goidhw16g = mkldnn_Abcdef16a,
    };
    
    public enum class Nmkldnn_prop_kind_t
    {
        // TODO: suggest renames
        /// Undefined propagation type.
        _prop_kind_undef = 0,
        /// Forward data propagation (training mode). In this mode primitives
        /// perform computations necessary for subsequent backward propagation.
        _forward_training = 64,
        /// Forward data propagation (inference mode). In this mode primitives
        /// perform only computations that are necessary for inference and omit
        /// computations that are necessary only for backward propagation.
        _forward_inference = 96,
        /// Forward data propagation (alias for @c mkldnn_forward_inference).
        _forward_scoring = mkldnn_forward_inference,
        /// Forward data propagation (alias for @c mkldnn_forward_training).
        _forward = mkldnn_forward_training,
        /// Backward propagation (with respect to all parameters).
        _backward = 128,
        /// Backward data propagation.
        _backward_data = 160,
        /// Backward weights propagation.
        _backward_weights = 192,
        /// Backward bias propagation.
        _backward_bias = 193,
    };
    
    public enum class Nmkldnn_primitive_kind_t
    {
        /// Undefined primitive
        _undefined_primitive,
        /// A reorder primitive.
        _reorder,
        /// A shuffle primitive.
        _shuffle,
        /// A (out-of-place) concat primitive.
        _concat,
        /// A sum primitive.
        _sum,
        /// A convolution primitive.
        _convolution,
        /// A deconvolution primitive.
        _deconvolution,
        /// An element-wise primitive.
        _eltwise,
        /// A softmax primitive.
        _softmax,
        /// A pooling primitive.
        _pooling,
        /// An LRN primitive.
        _lrn,
        /// An batch normalization primitive.
        _batch_normalization,
        /// An inner product primitive.
        _inner_product,
        /// A rnn primitive.
        _rnn,
        /// A matrix multiplication primitive.
        _gemm,
    };
    
    public enum class Nmkldnn_alg_kind_t
    {
        _alg_kind_undef,
        /// Direct convolution
        _convolution_direct = 0x1,
        /// Winograd convolution
        _convolution_winograd = 0x2,
        /// Convolution algorithm(either direct or Winograd) is chosen just in time
        _convolution_auto = 0x3,
        /// Direct deconvolution
        _deconvolution_direct = 0xa,
        /// Winograd deconvolution
        _deconvolution_winograd = 0xb,
        /// Eltwise: ReLU
        _eltwise_relu = 0x1f,
        /// Eltwise: hyperbolic tangent non-linearity (tanh)
        _eltwise_tanh = 0x2f,
        /// Eltwise: parametric exponential linear unit (elu)
        _eltwise_elu = 0x3f,
        /// Eltwise: square
        _eltwise_square = 0x4f,
        /// Eltwise: abs
        _eltwise_abs = 0x5f,
        /// Eltwise: square root
        _eltwise_sqrt = 0x6f,
        /// Eltwise: linear
        _eltwise_linear = 0x7f,
        /// Eltwise: bounded_relu
        _eltwise_bounded_relu = 0x8f,
        /// Eltwise: soft_relu
        _eltwise_soft_relu = 0x9f,
        /// Eltwise: logistic
        _eltwise_logistic = 0xaf,
        /// Eltwise: exponent
        _eltwise_exp = 0xbf,
        /// Eltwise: gelu
        ///
        /// @note Tanh approximation formula is used to approximate
        /// cumulative distribution function of a Gaussian
        _eltwise_gelu = 0xcf,
        /// Max pooling
        _pooling_max = 0x1ff,
        /// Average pooling include padding
        _pooling_avg_include_padding = 0x2ff,
        /// Average pooling exclude padding
        _pooling_avg_exclude_padding = 0x3ff,
        _pooling_avg = mkldnn_pooling_avg_exclude_padding,
        /// Local response normalization (LRN) across multiple channels
        _lrn_across_channels = 0xaff,
        /// LRN within a single channel
        _lrn_within_channel = 0xbff,
        /// RNN cell
        _vanilla_rnn = 0x1fff,
        /// LSTM cell
        _vanilla_lstm = 0x2fff,
        /// GRU cell
        _vanilla_gru = 0x3fff,
        /// GRU cell with linear before reset
        ///
        /// Modification of original GRU cell. Differs from #mkldnn_vanilla_gru
        /// in how the new memory gate is calculated:
        /// \f[ c_t = tanh(W_c*x_t + b_{c_x} + r_t*(U_c*h_{t-1}+b_{c_h})) \f]
        /// Primitive expects 4 biases on input:
        /// \f$[b_{u}, b_{r}, b_{c_x}, b_{c_h}]\f$
        _lbr_gru = 0x4fff,
    };
    
    public enum class Nmkldnn_normalization_flags_t
    {
        /// Use global statistics
        ///
        /// If specified
        ///  - on forward propagation use mean and variance provided by user (input)
        ///  - on backward propagation reduces the amount of computations, since
        ///    mean and variance are considered as constants
        ///
        ///  If not specified:
        ///   - on forward propagation mean and variance are computed and stored in
        ///     output
        ///   - on backward propagation compute full derivative wrt to data
        _use_global_stats = 0x1U,
        /// Use scale and shift parameters
        ///
        /// If specified:
        ///  - on forward propagation use scale and shift (aka scale and bias) for
        ///    the batch normalization results
        ///  - on backward propagation (for prop_kind == #mkldnn_backward) compute
        ///    diff wrt to scale and shift (hence one extra output used)
        ///
        /// If no specified:
        ///  - on backward propagation prop_kind == #mkldnn_backward_data has the
        ///    same behavior as prop_kind == #mkldnn_backward
        _use_scaleshift = 0x2U,
        /// Fuse with ReLU
        ///
        /// If specified:
        ///  - on inference this option behaves the same as if the primitive were
        ///    fused with ReLU via post ops API
        ///  - on training primitive requires workspace (required to be able to
        ///    perform backward pass)
        _fuse_norm_relu = 0x4U,
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_blocking_desc_t
    {
    public:
        /// The strides between the outermost blocks.
        /// In case of plain (non-blocked) formats the strides between dimensions.
        mkldnn_dims_t strides;
        // Innermost section
        // ASSUMPTION: the innermost blocks are always dense
        /// The number of innermost blocks, e.g. 3 in case of `OIhw_4i16o4i_`
        int inner_nblks;
        /// The size of the blocks, e.g. `{4, 16, 4}` in case of `OIhw_4i16o4i`
        mkldnn_dims_t inner_blks;
        /// The logical indices of the blocks, e.g. `{1, 0, 1}` in case of
        /// `4i16o4i`, because `i` is the 1st dim and `o` is the 0st dim
        mkldnn_dims_t inner_idxs;
    };
    
    public enum class Nmkldnn_wino_memory_format_t
    {
        /// Undefined memory format, used for empty memory descriptors.
        _wino_undef = 0,
        // Tensors of weights for 2x3 winograd convolutions.
        _wino_wei_aaOIoi, ///< Internal weights format for 2x3 Winograd
        _wino_wei_aaOio, ///< Internal weights format for 2x3 Winograd
        _wino_wei_aaOBiOo, ///< Internal weights format for 2x3 Winograd
        // Tensor of weights for 4x3 convolution.
        _wino_wei_OBaaIBOIio ///< Internal weights format for 4x3 Winograd
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_wino_desc_t
    {
    public:
        Nmkldnn_wino_memory_format_t wino_format;
        int r;
        int alpha;
        int ic;
        int oc;
        int ic_block;
        int oc_block;
        int ic2_block;
        int oc2_block;
        float adj_scale;
        size_t size;
    };
    
    public enum class Nmkldnn_rnn_packed_memory_format_t
    {
        _packed_format_undef = 0,
        _ldigo_p,
        _ldgoi_p
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_rnn_packed_desc_t
    {
    public:
        Nmkldnn_rnn_packed_memory_format_t format;
        int n_parts;
        int n;
        int ldb;
        int parts[MKLDNN_RNN_MAX_N_PARTS];
        size_t part_pack_size[MKLDNN_RNN_MAX_N_PARTS];
        unsigned pack_part[MKLDNN_RNN_MAX_N_PARTS];
        size_t offset_compensation;
        size_t size;
        char reserved[200];
    };
    
    public enum class Nmkldnn_memory_extra_flags_t
    {
        _memory_extra_flag_none = 0x0U,
        /// Indicates the weights have an additional buffer, that depends on the
        /// @p compensation_mask.
        ///
        /// For instance, in 4D case with the compensation mask equals (1 << 0)
        /// the additional buffer would consist of OC values:
        /// O[oc : 0,OC] =
        ///  -128 * SUM(ic : 0,IC; kh : 0,KH; kw : 0,KW){ weights(oc, ic, kh, kw) }
        _memory_extra_flag_compensation_conv_s8s8 = 0x1U,
        _memory_extra_flag_scale_adjust = 0x2U,
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_memory_extra_desc_t
    {
    public:
        /// The flags contain arbitrary extra information, such as compensation.
        /// @sa mkldnn_memory_extra_flags_t
        uint64_t flags;
        /// Compensation mask
        int compensation_mask;
        /// Scale applied to the data
        float scale_adjust;
        /// For future backwards compatibility
        char reserved[64];
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nformat_desc
    {
    public:
        /// Number of dimensions
        int ndims;
        /// Dimensions in the following order:
        /// - CNN data tensors: mini-batch, channel, spatial
        ///   (<code>{N, C, [[D,] H,] W}</code>)
        /// - CNN weight tensors: group (optional), output channel, input channel,
        ///   spatial (<code>{[G,] O, I, [[D,] H,] W}</code>)
        /// - RNN data tensors: time, mini-batch, channels (<code>{T, N, C}</code>)
        ///   or layers, directions, states, mini-batch, channels (<code>{L, D, S, N, C}</code>)
        /// - RNN weight tensor: layers, directions, input channel, gates, output channels
        ///   (<code>{L, D, I, G, O}</code>).
        ///
        /// @note
        ///    The order of dimensions does not depend on the memory format, so
        ///    whether the data is laid out in #mkldnn_nchw or #mkldnn_nhwc
        ///    the dims for 4D CN data tensor would be <code>{N, C, H, W}</code>.
        mkldnn_dims_t dims;
        /// Data type of the tensor elements.
        Nmkldnn_data_type_t data_type;
        /// Size of the data including padding in each dimension.
        mkldnn_dims_t padded_dims;
        /// Per-dimension offset from the padding to actual data, the top-level
        /// tensor with offsets applied must lie within the padding area.
        mkldnn_dims_t padded_offsets;
        /// Offset from memory origin to the current block, non-zero only in
        /// a description of a memory sub-block.
        mkldnn_dim_t offset0;
        /// Memory format kind.
        Nmkldnn_format_kind_t format_kind;
        union {
        /// Description of the data layout for memory formats that use
        /// blocking.
        Nmkldnn_blocking_desc_t blocking;
        /// Tensor of weights for integer 8bit winograd convolution.
        Nmkldnn_wino_desc_t wino_desc;
        /// Tensor of packed weights for RNN.
        Nmkldnn_rnn_packed_desc_t rnn_packed_desc;
        // ... other descriptions possible
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_memory_t
    {
    public:
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_convolution_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_convolution.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, #mkldnn_backward_data,
        /// #mkldnn_backward_weights, and #mkldnn_backward_bias.
        Nmkldnn_prop_kind_t prop_kind;
        /// The kind of the convolution algorithm. Possible values:
        /// #mkldnn_convolution_direct.
        Nmkldnn_alg_kind_t alg_kind;
        /// Source memory descriptor.
        mkldnn_memory_desc_t src_desc;
        /// Source gradient memory descriptor.
        mkldnn_memory_desc_t diff_src_desc;
        /// Weights memory descriptor.
        mkldnn_memory_desc_t weights_desc;
        /// Weights gradient memory descriptor.
        mkldnn_memory_desc_t diff_weights_desc;
        /// Bias memory descriptor.
        mkldnn_memory_desc_t bias_desc;
        /// Bias gradient memory descriptor.
        mkldnn_memory_desc_t diff_bias_desc;
        /// Destination memory descriptor.
        mkldnn_memory_desc_t dst_desc;
        /// Destination gradient memory descriptor.
        mkldnn_memory_desc_t diff_dst_desc;
        /// Convolution strides in each spatial dimension.
        mkldnn_dims_t strides;
        /// Convolution dilates in each spatial dimension.
        mkldnn_dims_t dilates;
        /// Padding in each spatial dimension. padding[0] is a padding in the
        /// beginning (@p padding_l), padding[1] is a padding in the end (@p
        /// padding_r).
        mkldnn_dims_t padding[2];
        /// The accumulator data type. Initialized automatically.
        Nmkldnn_data_type_t accum_data_type;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_shuffle_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_convolution.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, and #mkldnn_backward_data.
        Nmkldnn_prop_kind_t prop_kind;
        /// Source and destination memory descriptor,
        /// and source and destination gradient memory descriptor.
        mkldnn_memory_desc_t data_desc;
        /// axis for shuffling.
        int axis;
        /// number of groups in group convolution
        mkldnn_dim_t group_size;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_eltwise_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_eltwise.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, #mkldnn_backward, and #mkldnn_backward_data.
        Nmkldnn_prop_kind_t prop_kind;
        /// The kind of eltwise algorithm. Possible values: #mkldnn_eltwise_relu,
        /// #mkldnn_eltwise_tanh, #mkldnn_eltwise_elu, #mkldnn_eltwise_square,
        /// #mkldnn_eltwise_abs, #mkldnn_eltwise_sqrt, #mkldnn_eltwise_linear,
        /// #mkldnn_eltwise_bounded_relu, #mkldnn_eltwise_soft_relu,
        /// #mkldnn_eltwise_logistic and #mkldnn_eltwise_exp.
        Nmkldnn_alg_kind_t alg_kind;
        /// Source and destination memory descriptor.
        mkldnn_memory_desc_t data_desc;
        /// Source and destination gradient memory descriptor.
        mkldnn_memory_desc_t diff_data_desc;
        /// Algorithm specific parameter.
        /// Accordance table:
        ///  - #mkldnn_eltwise_relu: @p alpha -- negative slope, @p beta ignored
        ///  - #mkldnn_eltwise_tanh: @p alpha and @p beta ignored
        ///  - #mkldnn_eltwise_elu: @p alpha -- negative slope, @p beta ignored
        ///  - #mkldnn_eltwise_square: @p alpha and @p beta ignored
        ///  - #mkldnn_eltwise_abs: @p alpha and @p beta ignored
        ///  - #mkldnn_eltwise_sqrt: @p alpha and @p beta ignored
        ///  - #mkldnn_eltwise_linear: @p alpha -- scale, @p beta -- shift
        ///  - #mkldnn_eltwise_bounded_relu: @p alpha -- upper bound, @p beta ignored
        ///  - #mkldnn_eltwise_soft_relu: @p alpha and @p beta ignored
        ///  - #mkldnn_eltwise_logistic: @p alpha and @p beta ignored
        ///  - #mkldnn_eltwise_exp: @p alpha and @p beta ignored
        float alpha, beta;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_softmax_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_softmax.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training and
        /// #mkldnn_forward_inference.
        Nmkldnn_prop_kind_t prop_kind;
        /// Source and destination memory descriptor.
        mkldnn_memory_desc_t data_desc;
        /// Source and Destination of gradient memory descriptor.
        mkldnn_memory_desc_t diff_desc;
        /// The axis along which to perform the softmax.
        int softmax_axis;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_pooling_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_pooling.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, #mkldnn_backward, and #mkldnn_backward_data.
        Nmkldnn_prop_kind_t prop_kind;
        /// The kind of pooling algorithm.
        /// Possible values: #mkldnn_pooling_max,
        /// #mkldnn_pooling_avg_include_padding, and
        /// #mkldnn_pooling_avg_exclude_padding.
        Nmkldnn_alg_kind_t alg_kind;
        /// Source memory descriptor.
        mkldnn_memory_desc_t src_desc;
        /// Source gradient memory descriptor.
        mkldnn_memory_desc_t diff_src_desc;
        /// Destination memory descriptor.
        mkldnn_memory_desc_t dst_desc;
        /// Destination gradient memory descriptor.
        mkldnn_memory_desc_t diff_dst_desc;
        /// Pooling kernel strides for spatial dimensions.
        mkldnn_dims_t strides;
        /// Pooling kernel spatial dimensions.
        mkldnn_dims_t kernel;
        /// Padding in each spatial dimension. padding[0] is a padding in the
        /// beginning (@p padding_l), padding[1] is a padding in the end (@p
        /// padding_r).
        mkldnn_dims_t padding[2];
        /// The accumulator data type. Initialized automatically.
        Nmkldnn_data_type_t accum_data_type;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_lrn_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_lrn.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, #mkldnn_backward, and #mkldnn_backward_data.
        Nmkldnn_prop_kind_t prop_kind;
        /// LRN algorithm. Possible values: #mkldnn_lrn_within_channel and
        /// #mkldnn_lrn_across_channels.
        Nmkldnn_alg_kind_t alg_kind;
        /// Source and destination memory descriptor.
        mkldnn_memory_desc_t data_desc;
        /// Source and destination gradient memory descriptor.
        mkldnn_memory_desc_t diff_data_desc;
        /// The number of channels to sum over (for cross-channel LRN) or the side
        /// length of the square region to sum over (for within-channel LRN).
        mkldnn_dim_t local_size;
        /// LRN alpha parameter.
        float lrn_alpha;
        /// LRN beta parameter.
        float lrn_beta;
        /// LRN k parameter.
        float lrn_k;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_batch_normalization_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_batch_normalization.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, #mkldnn_backward, and #mkldnn_backward_data.
        Nmkldnn_prop_kind_t prop_kind;
        /// Source and destination memory descriptor.
        mkldnn_memory_desc_t data_desc;
        /// Source and destination gradient memory descriptor.
        mkldnn_memory_desc_t diff_data_desc;
        /// Scale and shift data and gradient memory descriptors.
        ///
        /// Scaleshift memory descriptor uses 2D #mkldnn_nc format[2,Channels]. 1-st
        /// dimension contains gamma parameter, 2-nd dimension contains beta
        /// parameter.
        mkldnn_memory_desc_t data_scaleshift_desc;
        mkldnn_memory_desc_t diff_data_scaleshift_desc;
        /// Statistics memory descriptor.
        ///
        /// Statistics (mean or variance) descriptor use 1D #mkldnn_x format[Channels].
        mkldnn_memory_desc_t stat_desc;
        /// Batch normalization epsilon parameter.
        float batch_norm_epsilon;
        unsigned flags;
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_inner_product_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_inner_product.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, #mkldnn_backward_data,
        /// #mkldnn_backward_weights, and #mkldnn_backward_bias.
        Nmkldnn_prop_kind_t prop_kind;
        /// Source memory descriptor.
        mkldnn_memory_desc_t src_desc;
        /// Source gradient memory descriptor.
        mkldnn_memory_desc_t diff_src_desc;
        /// Weights memory descriptor.
        mkldnn_memory_desc_t weights_desc;
        /// Weights gradient memory descriptor.
        mkldnn_memory_desc_t diff_weights_desc;
        /// Bias memory descriptor.
        mkldnn_memory_desc_t bias_desc;
        /// Bias gradient memory descriptor.
        mkldnn_memory_desc_t diff_bias_desc;
        /// Destination memory descriptor.
        mkldnn_memory_desc_t dst_desc;
        /// Destination gradient memory descriptor.
        mkldnn_memory_desc_t diff_dst_desc;
        /// The accumulator data type. Initialized automatically.
        Nmkldnn_data_type_t accum_data_type;
    };
    
    public enum class Nmkldnn_rnn_flags_t
    {
        _rnn_flags_undef = 0x0
    };
    
    public enum class Nmkldnn_rnn_direction_t
    {
        /// Unidirectional execution of RNN primitive from left to right.
        _unidirectional_left2right,
        /// Unidirectional execution of RNN primitive from right to left.
        _unidirectional_right2left,
        /// Bidirectional execution of RNN primitive with concatenation of the
        /// results.
        _bidirectional_concat,
        /// Bidirectional execution of RNN primitive with summation of the
        /// results.
        _bidirectional_sum,
        _unidirectional = mkldnn_unidirectional_left2right,
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_rnn_desc_t
    {
    public:
        /// The kind of primitive. Used for self-identifying the primitive
        /// descriptor. Must be #mkldnn_rnn.
        Nmkldnn_primitive_kind_t primitive_kind;
        /// The kind of propagation. Possible values: #mkldnn_forward_training,
        /// #mkldnn_forward_inference, and #mkldnn_backward.
        Nmkldnn_prop_kind_t prop_kind;
        /// RNN cell kind. Must be one of #mkldnn_vanilla_rnn,
        /// #mkldnn_vanilla_lstm, #mkldnn_vanilla_gru, or #mkldnn_lbr_gru.
        Nmkldnn_alg_kind_t cell_kind;
        /// The direction of RNN primitive execution.
        Nmkldnn_rnn_direction_t direction;
        /// Source layer memory descriptor.
        mkldnn_memory_desc_t src_layer_desc;
        /// Source iteration memory descriptor for hidden state.
        mkldnn_memory_desc_t src_iter_desc;
        /// Source iteration memory descriptor for cell state.
        mkldnn_memory_desc_t src_iter_c_desc;
        /// Weights layer memory descriptor.
        mkldnn_memory_desc_t weights_layer_desc;
        /// Weights iteration memory descriptor.
        mkldnn_memory_desc_t weights_iter_desc;
        /// Bias memory descriptor.
        mkldnn_memory_desc_t bias_desc;
        /// Destination layer memory descriptor.
        mkldnn_memory_desc_t dst_layer_desc;
        /// Destination iter memory descriptor for hidden state.
        mkldnn_memory_desc_t dst_iter_desc;
        /// Destination iter memory descriptor for cell state.
        mkldnn_memory_desc_t dst_iter_c_desc;
        /// Placeholders
        mkldnn_memory_desc_t placeholder_desc;
        mkldnn_memory_desc_t placeholder2_desc;
        /// Source gradient layer memory descriptor.
        mkldnn_memory_desc_t diff_src_layer_desc;
        /// Source gradient iter memory descriptor for hidden state.
        mkldnn_memory_desc_t diff_src_iter_desc;
        /// Source gradient iter memory descriptor for cell state.
        mkldnn_memory_desc_t diff_src_iter_c_desc;
        /// Weights gradient layer memory descriptor.
        mkldnn_memory_desc_t diff_weights_layer_desc;
        /// Weights gradient iter memory descriptor.
        mkldnn_memory_desc_t diff_weights_iter_desc;
        /// Bias gradient memory descriptor.
        mkldnn_memory_desc_t diff_bias_desc;
        /// Destination gradient layer memory descriptor.
        mkldnn_memory_desc_t diff_dst_layer_desc;
        /// Destination gradient iteration memory descriptor for hidden state.
        mkldnn_memory_desc_t diff_dst_iter_desc;
        /// Destination gradient iteration memory descriptor for cell state.
        mkldnn_memory_desc_t diff_dst_iter_c_desc;
        /// Placeholders
        mkldnn_memory_desc_t diff_placeholder_desc;
        mkldnn_memory_desc_t diff_placeholder2_desc;
        /// RNN cell flags
        unsigned int flags;
        /// Activation function used for vanilla_rnn cell kind.
        /// Must be either #mkldnn_eltwise_relu or #mkldnn_eltwise_tanh.
        Nmkldnn_alg_kind_t activation_kind;
        float alpha;
        float beta;
    };
    
    public enum class Nmkldnn_engine_kind_t
    {
        /// An unspecified engine.
        _any_engine,
        /// CPU engine.
        _cpu,
        /// GPU engine.
        _gpu,
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_engine_t
    {
    public:
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_primitive_desc_t
    {
    public:
    };
    
    public enum class Nmkldnn_scratchpad_mode_t
    {
        /// The library manages scratchpad (default)
        _scratchpad_mode_library,
        /// A user shall query and provide the scratchpad memory to primitives
        _scratchpad_mode_user,
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_primitive_attr_t
    {
    public:
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_post_ops_t
    {
    public:
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_primitive_t
    {
    public:
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct Nmkldnn_exec_arg_t
    {
    public:
        int arg; ///< An argument index, e.g. MKLDNN_ARG_SRC
        mkldnn_memory_t memory; ///< Input/output memory
    };
    
    public enum class Nmkldnn_query_t
    {
        _query_undef = 0, ///< no query
        _query_engine, ///< execution engine
        _query_primitive_kind, ///< primitive kind
        _query_num_of_inputs_s32, ///< number of inputs expected
        _query_num_of_outputs_s32, ///< number of outputs expected
        Nmkldnn_query_time_estimate_f64, ///< runtime estimation (seconds)
        _query_memory_consumption_s64, ///< memory consumption -- extra
        ///  (scratch) memory, additional to
        ///  all inputs and outputs memory
        ///  (bytes)
        _query_scratchpad_engine, ///< scratchpad engine -- engine to be used
        ///  for creating scratchpad memory
        _query_impl_info_str, ///< implementation name
        // memory and op descriptor section
        _query_some_d = 64, ///< stub
        _query_op_d, ///< op descriptor
        _query_convolution_d, ///< convolution descriptor
        _query_deconvolution_d, ///< deconvolution descriptor
        _query_shuffle_d, ///< shuffle descriptor
        _query_eltwise_d, ///< eltwise descriptor
        _query_softmax_d, ///< softmax descriptor
        _query_pooling_d, ///< pooling descriptor
        _query_lrn_d, ///< lrn descriptor
        _query_batch_normalization_d, ///< batch normalization descriptor
        _query_inner_product_d, ///< inner product descriptor
        _query_rnn_d, ///< rnn descriptor
        _query_gemm_d, ///< GEMM descriptor
        // memory descriptor section
        _query_some_md = 128, ///< stub
        _query_src_md, ///< source memory desc
        _query_diff_src_md, ///< source gradient memory desc
        _query_weights_md, ///< weights memory descriptor desc
        _query_diff_weights_md, ///< weights grad. memory desc
        _query_dst_md, ///< destination memory desc
        _query_diff_dst_md, ///< destination grad. memory desc
        _query_workspace_md, ///< workspace memory desc
        _query_scratchpad_md, ///< scratchpad memory desc
    };
    
    public enum class Nmkldnn_stream_flags_t
    {
        /// Default order execution. Either in-order or out-of-order depending on
        /// the runtime.
        _stream_default_order = 0x1U,
        /// In-order execution.
        _stream_in_order = 0x2U,
        /// Out-of-order execution.
        _stream_out_of_order = 0x4U,
        /// Default stream configuration.
        _stream_default_flags = mkldnn_stream_default_order,
    };
    
    [System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
    public value struct N*mkldnn_stream_t
    {
    public:
    };
    
} }