 
 
 

using namespace System;
// http://msdn.microsoft.com/en-us/library/ee847423(v=vs.110).aspx
namespace Intel.MklDnn
{
	public ref class MklDnnException sealed : Exception
	{
	public:
		MklDnnException(String^ message, NMklDnnStatus status)
			: Exception(message)
			, Status(status)
		{}

		initonly NMklDnnStatus Status;
	};

	public ref class MklDnn abstract sealed
	{
	public:
		static void ThrowOnError(NMklDnnStatus status)
		{
			if (status != NMklDnnStatus::StsNoErr)
			{
				auto message = GetStatusText(status);
				throw gcnew MklDnnException(message, status);
			}
		}

		static String^ GetStatusText(NMklDnnStatus status)
		{
			auto characters = ippGetStatusString((MklDnnStatus)status);
			return msclr::interop::marshal_as<String^>(characters);
		}

        static Nmkldnn_status_t _primitive_desc_iterator_create(mkldnn_primitive_desc_iterator_t * iterator, const_mkldnn_op_desc_t op_ desc, const_mkldnn_primitive_attr_t attr, mkldnn_engine_t engine, const_mkldnn_primitive_desc_t hint_forward_primitive_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_iterator_create(iterator, desc, attr, engine, desc)); }
        
        static Nmkldnn_status_t _primitive_desc_iterator_next(mkldnn_primitive_desc_iterator_t iterator)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_iterator_next(iterator)); }
        
        static mkldnn_primitive_desc_t _primitive_desc_iterator_fetch(const_mkldnn_primitive_desc_iterator_t iterator)
        {    return mkldnn_primitive_desc_iterator_fetch(iterator); }
        
        static Nmkldnn_status_t _primitive_desc_iterator_destroy(mkldnn_primitive_desc_iterator_t iterator)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_iterator_destroy(iterator)); }
        
        static Nmkldnn_status_t _primitive_desc_create(mkldnn_primitive_desc_t *primitive_ desc, const_mkldnn_op_desc_t op_ desc, const_mkldnn_primitive_attr_t attr, mkldnn_engine_t engine, const_mkldnn_primitive_desc_t hint_forward_primitive_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_create(desc, desc, attr, engine, desc)); }
        
        static Nmkldnn_status_t _primitive_desc_clone(mkldnn_primitive_desc_t *primitive_ desc, const_mkldnn_primitive_desc_t existing_primitive_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_clone(desc, desc)); }
        
        static Nmkldnn_status_t _primitive_desc_get_attr(const_mkldnn_primitive_desc_t primitive_ desc, const_mkldnn_primitive_attr_t * attr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_get_attr(desc, attr)); }
        
        static Nmkldnn_status_t _primitive_desc_destroy(mkldnn_primitive_desc_t primitive_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_destroy(desc)); }
        
        static Nmkldnn_status_t _primitive_desc_query(const_mkldnn_primitive_desc_t primitive_ desc, Nmkldnn_query_t what, int index, void * result)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_desc_query(desc, static_cast<mkldnn_query_t>(what), index, result)); }
        
        static const mkldnn_memory_desc_t *mkldnn_primitive_desc_query_md(const_mkldnn_primitive_desc_t primitive_ desc, Nmkldnn_query_t what, int index)
        {    return *mkldnn_primitive_desc_query_md(desc, static_cast<mkldnn_query_t>(what), index); }
        
        static int _primitive_desc_query_s32(const_mkldnn_primitive_desc_t primitive_ desc, Nmkldnn_query_t what, int index)
        {    return mkldnn_primitive_desc_query_s32(desc, static_cast<mkldnn_query_t>(what), index); }
        
        static Nmkldnn_status_t _primitive_create(mkldnn_primitive_t * primitive, const_mkldnn_primitive_desc_t primitive_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_create(primitive, desc)); }
        
        static Nmkldnn_status_t _primitive_execute(const_mkldnn_primitive_t primitive, mkldnn_stream_t stream, int nargs, Nmkldnn_exec_arg_t * args)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_execute(primitive, stream, nargs, reinterpret_cast<mkldnn_exec_arg_t*>(args))); }
        
        static Nmkldnn_status_t _primitive_get_primitive_desc(const_mkldnn_primitive_t primitive, const_mkldnn_primitive_desc_t *primitive_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_get_primitive_desc(primitive, desc)); }
        
        static Nmkldnn_status_t _primitive_destroy(mkldnn_primitive_t primitive)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_destroy(primitive)); }
        
        static Nmkldnn_status_t _primitive_attr_create(mkldnn_primitive_attr_t * attr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_create(attr)); }
        
        static Nmkldnn_status_t _primitive_attr_clone(mkldnn_primitive_attr_t * attr, const_mkldnn_primitive_attr_t existing_ attr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_clone(attr, attr)); }
        
        static Nmkldnn_status_t _primitive_attr_destroy(mkldnn_primitive_attr_t attr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_destroy(attr)); }
        
        static Nmkldnn_status_t _primitive_attr_get_scratchpad_mode(const_mkldnn_primitive_attr_t attr, Nmkldnn_scratchpad_mode_t * mode)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_get_scratchpad_mode(attr, reinterpret_cast<mkldnn_scratchpad_mode_t*>(mode))); }
        
        static Nmkldnn_status_t _primitive_attr_set_scratchpad_mode(mkldnn_primitive_attr_t attr, Nmkldnn_scratchpad_mode_t mode)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_set_scratchpad_mode(attr, static_cast<mkldnn_scratchpad_mode_t>(mode))); }
        
        static Nmkldnn_status_t _primitive_attr_get_output_scales(const_mkldnn_primitive_attr_t attr, mkldnn_dim_t * count, int * mask, const float ** scales)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_get_output_scales(attr, count, mask, scales)); }
        
        static Nmkldnn_status_t _primitive_attr_set_output_scales(mkldnn_primitive_attr_t attr, mkldnn_dim_t count, int mask, const float * scales)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_set_output_scales(attr, count, mask, scales)); }
        
        static Nmkldnn_status_t _primitive_attr_get_post_ops(const_mkldnn_primitive_attr_t attr, const_mkldnn_post_ops_t *post_ ops)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_get_post_ops(attr, ops)); }
        
        static Nmkldnn_status_t _primitive_attr_set_post_ops(mkldnn_primitive_attr_t attr, const_mkldnn_post_ops_t post_ ops)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_set_post_ops(attr, ops)); }
        
        static Nmkldnn_status_t _post_ops_create(mkldnn_post_ops_t *post_ ops)
        {    return static_cast<Nmkldnnstatust>(mkldnn_post_ops_create(ops)); }
        
        static Nmkldnn_status_t _post_ops_destroy(mkldnn_post_ops_t post_ ops)
        {    return static_cast<Nmkldnnstatust>(mkldnn_post_ops_destroy(ops)); }
        
        static int _post_ops_len(const_mkldnn_post_ops_t post_ ops)
        {    return mkldnn_post_ops_len(ops); }
        
        static Nmkldnn_primitive_kind_t _post_ops_get_kind(const_mkldnn_post_ops_t post_ ops, int index)
        {    return static_cast<Nmkldnnprimitivekindt>(mkldnn_post_ops_get_kind(ops, index)); }
        
        static Nmkldnn_status_t _post_ops_append_sum(mkldnn_post_ops_t post_ ops, float scale)
        {    return static_cast<Nmkldnnstatust>(mkldnn_post_ops_append_sum(ops, scale)); }
        
        static Nmkldnn_status_t _post_ops_get_params_sum(const_mkldnn_post_ops_t post_ ops, int index, float * scale)
        {    return static_cast<Nmkldnnstatust>(mkldnn_post_ops_get_params_sum(ops, index, scale)); }
        
        static Nmkldnn_status_t _post_ops_append_eltwise(mkldnn_post_ops_t post_ ops, float scale, Nmkldnn_alg_kind_t alg, float alpha, float beta)
        {    return static_cast<Nmkldnnstatust>(mkldnn_post_ops_append_eltwise(ops, scale, static_cast<mkldnn_alg_kind_t>(alg), alpha, beta)); }
        
        static Nmkldnn_status_t _post_ops_get_params_eltwise(const_mkldnn_post_ops_t post_ ops, int index, float * scale, Nmkldnn_alg_kind_t * alg, float * alpha, float * beta)
        {    return static_cast<Nmkldnnstatust>(mkldnn_post_ops_get_params_eltwise(ops, index, scale, reinterpret_cast<mkldnn_alg_kind_t*>(alg), alpha, beta)); }
        
        static Nmkldnn_status_t _memory_desc_init_by_strides(mkldnn_memory_desc_t *memory_ desc, int ndims, const mkldnn_dims_t dims, Nmkldnn_data_type_t data_ type, const mkldnn_dims_t strides)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_desc_init_by_strides(desc, ndims, dims, static_cast<mkldnn_data_type_t>(type), strides)); }
        
        static Nmkldnn_status_t _memory_desc_init_by_tag(mkldnn_memory_desc_t *memory_ desc, int ndims, const mkldnn_dims_t dims, Nmkldnn_data_type_t data_ type, Nmkldnn_format_tag_t tag)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_desc_init_by_tag(desc, ndims, dims, static_cast<mkldnn_data_type_t>(type), static_cast<mkldnn_format_tag_t>(tag))); }
        
        static Nmkldnn_status_t _memory_desc_init_submemory(mkldnn_memory_desc_t *memory_ desc, const mkldnn_memory_desc_t *parent_memory_ desc, const mkldnn_dims_t dims, const mkldnn_dims_t offsets)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_desc_init_submemory(desc, desc, dims, offsets)); }
        
        static int _memory_desc_equal(const mkldnn_memory_desc_t * lhs, const mkldnn_memory_desc_t * rhs)
        {    return mkldnn_memory_desc_equal(lhs, rhs); }
        
        static size_t _memory_desc_get_size(const mkldnn_memory_desc_t *memory_ desc)
        {    return mkldnn_memory_desc_get_size(desc); }
        
        static Nmkldnn_status_t _memory_create(mkldnn_memory_t * memory, const mkldnn_memory_desc_t *memory_ desc, mkldnn_engine_t engine, void * handle)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_create(memory, desc, engine, handle)); }
        
        static Nmkldnn_status_t _memory_get_memory_desc(const_mkldnn_memory_t memory, const mkldnn_memory_desc_t **memory_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_get_memory_desc(memory, desc)); }
        
        static Nmkldnn_status_t _memory_get_engine(const_mkldnn_memory_t memory, mkldnn_engine_t * engine)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_get_engine(memory, engine)); }
        
        static Nmkldnn_status_t _memory_map_data(const_mkldnn_memory_t memory, void **mapped_ ptr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_map_data(memory, ptr)); }
        
        static Nmkldnn_status_t _memory_unmap_data(const_mkldnn_memory_t memory, void *mapped_ ptr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_unmap_data(memory, ptr)); }
        
        static Nmkldnn_status_t _memory_get_data_handle(const_mkldnn_memory_t memory, void ** handle)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_get_data_handle(memory, handle)); }
        
        static Nmkldnn_status_t _memory_set_data_handle(mkldnn_memory_t memory, void * handle)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_set_data_handle(memory, handle)); }
        
        static Nmkldnn_status_t _memory_get_ocl_mem_object(const_mkldnn_memory_t memory, cl_mem *mem_ object)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_get_ocl_mem_object(memory, object)); }
        
        static Nmkldnn_status_t _memory_set_ocl_mem_object(mkldnn_memory_t memory, cl_mem mem_ object)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_set_ocl_mem_object(memory, object)); }
        
        static Nmkldnn_status_t _memory_destroy(mkldnn_memory_t memory)
        {    return static_cast<Nmkldnnstatust>(mkldnn_memory_destroy(memory)); }
        
        static Nmkldnn_status_t _reorder_primitive_desc_create(mkldnn_primitive_desc_t *reorder_primitive_ desc, const mkldnn_memory_desc_t *src_ md, mkldnn_engine_t src_ engine, const mkldnn_memory_desc_t *dst_ md, mkldnn_engine_t dst_ engine, const_mkldnn_primitive_attr_t attr)
        {    return static_cast<Nmkldnnstatust>(mkldnn_reorder_primitive_desc_create(desc, md, engine, md, engine, attr)); }
        
        static Nmkldnn_status_t _concat_primitive_desc_create(mkldnn_primitive_desc_t *concat_primitive_ desc, const mkldnn_memory_desc_t *dst_ md, int n, int concat_ dimension, const mkldnn_memory_desc_t *src_ mds, const_mkldnn_primitive_attr_t attr, mkldnn_engine_t engine)
        {    return static_cast<Nmkldnnstatust>(mkldnn_concat_primitive_desc_create(desc, md, n, dimension, mds, attr, engine)); }
        
        static Nmkldnn_status_t _sum_primitive_desc_create(mkldnn_primitive_desc_t *sum_primitive_ desc, const mkldnn_memory_desc_t *dst_ mds, int n, const float * scales, const mkldnn_memory_desc_t *src_ mds, const_mkldnn_primitive_attr_t attr, mkldnn_engine_t engine)
        {    return static_cast<Nmkldnnstatust>(mkldnn_sum_primitive_desc_create(desc, mds, n, scales, mds, attr, engine)); }
        
        static Nmkldnn_status_t _convolution_forward_desc_init(Nmkldnn_convolution_desc_t *conv_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_convolution_forward_desc_init(reinterpret_cast<mkldnn_convolution_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, l, r)); }
        
        static Nmkldnn_status_t _dilated_convolution_forward_desc_init(Nmkldnn_convolution_desc_t *conv_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t dilates, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_dilated_convolution_forward_desc_init(reinterpret_cast<mkldnn_convolution_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, dilates, l, r)); }
        
        static Nmkldnn_status_t _convolution_backward_data_desc_init(Nmkldnn_convolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_convolution_backward_data_desc_init(reinterpret_cast<mkldnn_convolution_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, strides, l, r)); }
        
        static Nmkldnn_status_t _dilated_convolution_backward_data_desc_init(Nmkldnn_convolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t dilates, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_dilated_convolution_backward_data_desc_init(reinterpret_cast<mkldnn_convolution_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, strides, dilates, l, r)); }
        
        static Nmkldnn_status_t _convolution_backward_weights_desc_init(Nmkldnn_convolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *diff_weights_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_convolution_backward_weights_desc_init(reinterpret_cast<mkldnn_convolution_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, l, r)); }
        
        static Nmkldnn_status_t _dilated_convolution_backward_weights_desc_init(Nmkldnn_convolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *diff_weights_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t dilates, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_dilated_convolution_backward_weights_desc_init(reinterpret_cast<mkldnn_convolution_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, dilates, l, r)); }
        
        static Nmkldnn_status_t _deconvolution_forward_desc_init(mkldnn_deconvolution_desc_t *conv_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_deconvolution_forward_desc_init(desc, static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, l, r)); }
        
        static Nmkldnn_status_t _dilated_deconvolution_forward_desc_init(mkldnn_deconvolution_desc_t *conv_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t dilates, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_dilated_deconvolution_forward_desc_init(desc, static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, dilates, l, r)); }
        
        static Nmkldnn_status_t _deconvolution_backward_data_desc_init(mkldnn_deconvolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_deconvolution_backward_data_desc_init(desc, static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, strides, l, r)); }
        
        static Nmkldnn_status_t _dilated_deconvolution_backward_data_desc_init(mkldnn_deconvolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t dilates, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_dilated_deconvolution_backward_data_desc_init(desc, static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, strides, dilates, l, r)); }
        
        static Nmkldnn_status_t _deconvolution_backward_weights_desc_init(mkldnn_deconvolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *diff_weights_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_deconvolution_backward_weights_desc_init(desc, static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, l, r)); }
        
        static Nmkldnn_status_t _dilated_deconvolution_backward_weights_desc_init(mkldnn_deconvolution_desc_t *conv_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *diff_weights_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t dilates, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_dilated_deconvolution_backward_weights_desc_init(desc, static_cast<mkldnn_alg_kind_t>(kind), desc, desc, desc, desc, strides, dilates, l, r)); }
        
        static Nmkldnn_status_t _shuffle_forward_desc_init(Nmkldnn_shuffle_desc_t *shuffle_ desc, Nmkldnn_prop_kind_t prop_ kind, const mkldnn_memory_desc_t *data_ desc, int axis, mkldnn_dim_t group_ size)
        {    return static_cast<Nmkldnnstatust>(mkldnn_shuffle_forward_desc_init(reinterpret_cast<mkldnn_shuffle_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), desc, axis, size)); }
        
        static Nmkldnn_status_t _shuffle_backward_desc_init(Nmkldnn_shuffle_desc_t *shuffle_ desc, const mkldnn_memory_desc_t *diff_data_ desc, int axis, mkldnn_dim_t group_ size)
        {    return static_cast<Nmkldnnstatust>(mkldnn_shuffle_backward_desc_init(reinterpret_cast<mkldnn_shuffle_desc_t*>(desc), desc, axis, size)); }
        
        static Nmkldnn_status_t _eltwise_forward_desc_init(Nmkldnn_eltwise_desc_t *eltwise_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *data_ desc, float alpha, float beta)
        {    return static_cast<Nmkldnnstatust>(mkldnn_eltwise_forward_desc_init(reinterpret_cast<mkldnn_eltwise_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, alpha, beta)); }
        
        static Nmkldnn_status_t _eltwise_backward_desc_init(Nmkldnn_eltwise_desc_t *eltwise_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_data_ desc, const mkldnn_memory_desc_t *data_ desc, float alpha, float beta)
        {    return static_cast<Nmkldnnstatust>(mkldnn_eltwise_backward_desc_init(reinterpret_cast<mkldnn_eltwise_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, alpha, beta)); }
        
        static Nmkldnn_status_t _softmax_forward_desc_init(Nmkldnn_softmax_desc_t *softmax_ desc, Nmkldnn_prop_kind_t prop_ kind, const mkldnn_memory_desc_t *data_ desc, int softmax_ axis)
        {    return static_cast<Nmkldnnstatust>(mkldnn_softmax_forward_desc_init(reinterpret_cast<mkldnn_softmax_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), desc, axis)); }
        
        static Nmkldnn_status_t _softmax_backward_desc_init(Nmkldnn_softmax_desc_t *softmax_ desc, const mkldnn_memory_desc_t *diff_ desc, const mkldnn_memory_desc_t *data_ desc, int softmax_ axis)
        {    return static_cast<Nmkldnnstatust>(mkldnn_softmax_backward_desc_init(reinterpret_cast<mkldnn_softmax_desc_t*>(desc), desc, desc, axis)); }
        
        static Nmkldnn_status_t _pooling_forward_desc_init(Nmkldnn_pooling_desc_t *pool_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t kernel, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_pooling_forward_desc_init(reinterpret_cast<mkldnn_pooling_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, strides, kernel, l, r)); }
        
        static Nmkldnn_status_t _pooling_backward_desc_init(Nmkldnn_pooling_desc_t *pool_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_src_ desc, const mkldnn_memory_desc_t *diff_dst_ desc, const mkldnn_dims_t strides, const mkldnn_dims_t kernel, const mkldnn_dims_t padding_ l, const mkldnn_dims_t padding_ r)
        {    return static_cast<Nmkldnnstatust>(mkldnn_pooling_backward_desc_init(reinterpret_cast<mkldnn_pooling_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, strides, kernel, l, r)); }
        
        static Nmkldnn_status_t _lrn_forward_desc_init(Nmkldnn_lrn_desc_t *lrn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *data_ desc, mkldnn_dim_t local_ size, float alpha, float beta, float k)
        {    return static_cast<Nmkldnnstatust>(mkldnn_lrn_forward_desc_init(reinterpret_cast<mkldnn_lrn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(kind), desc, size, alpha, beta, k)); }
        
        static Nmkldnn_status_t _lrn_backward_desc_init(Nmkldnn_lrn_desc_t *lrn_ desc, Nmkldnn_alg_kind_t alg_ kind, const mkldnn_memory_desc_t *diff_data_ desc, const mkldnn_memory_desc_t *data_ desc, mkldnn_dim_t local_ size, float alpha, float beta, float k)
        {    return static_cast<Nmkldnnstatust>(mkldnn_lrn_backward_desc_init(reinterpret_cast<mkldnn_lrn_desc_t*>(desc), static_cast<mkldnn_alg_kind_t>(kind), desc, desc, size, alpha, beta, k)); }
        
        static Nmkldnn_status_t _batch_normalization_forward_desc_init(Nmkldnn_batch_normalization_desc_t *bnrm_ desc, Nmkldnn_prop_kind_t prop_ kind, const mkldnn_memory_desc_t *data_ desc, float epsilon, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_batch_normalization_forward_desc_init(reinterpret_cast<mkldnn_batch_normalization_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), desc, epsilon, flags)); }
        
        static Nmkldnn_status_t _batch_normalization_backward_desc_init(Nmkldnn_batch_normalization_desc_t *bnrm_ desc, Nmkldnn_prop_kind_t prop_ kind, const mkldnn_memory_desc_t *diff_data_ desc, const mkldnn_memory_desc_t *data_ desc, float epsilon, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_batch_normalization_backward_desc_init(reinterpret_cast<mkldnn_batch_normalization_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), desc, desc, epsilon, flags)); }
        
        static Nmkldnn_status_t _inner_product_forward_desc_init(Nmkldnn_inner_product_desc_t *ip_ desc, Nmkldnn_prop_kind_t prop_ kind, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_inner_product_forward_desc_init(reinterpret_cast<mkldnn_inner_product_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), desc, desc, desc, desc)); }
        
        static Nmkldnn_status_t _inner_product_backward_data_desc_init(Nmkldnn_inner_product_desc_t *ip_ desc, const mkldnn_memory_desc_t *diff_src_ desc, const mkldnn_memory_desc_t *weights_ desc, const mkldnn_memory_desc_t *diff_dst_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_inner_product_backward_data_desc_init(reinterpret_cast<mkldnn_inner_product_desc_t*>(desc), desc, desc, desc)); }
        
        static Nmkldnn_status_t _inner_product_backward_weights_desc_init(Nmkldnn_inner_product_desc_t *ip_ desc, const mkldnn_memory_desc_t *src_ desc, const mkldnn_memory_desc_t *diff_weights_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_ desc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_inner_product_backward_weights_desc_init(reinterpret_cast<mkldnn_inner_product_desc_t*>(desc), desc, desc, desc, desc)); }
        
        static Nmkldnn_status_t _primitive_attr_set_rnn_data_qparams(mkldnn_primitive_attr_t attr, const float scale, const float shift)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_set_rnn_data_qparams(attr, scale, shift)); }
        
        static Nmkldnn_status_t _primitive_attr_set_rnn_weights_qparams(mkldnn_primitive_attr_t attr, mkldnn_dim_t count, int mask, const float *weights_ scales)
        {    return static_cast<Nmkldnnstatust>(mkldnn_primitive_attr_set_rnn_weights_qparams(attr, count, mask, scales)); }
        
        static Nmkldnn_status_t _vanilla_rnn_forward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t activation, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, unsigned flags, float alpha, float beta)
        {    return static_cast<Nmkldnnstatust>(mkldnn_vanilla_rnn_forward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(activation), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, flags, alpha, beta)); }
        
        static Nmkldnn_status_t _vanilla_rnn_backward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_alg_kind_t activation, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, const mkldnn_memory_desc_t *diff_src_layer_ desc, const mkldnn_memory_desc_t *diff_src_iter_ desc, const mkldnn_memory_desc_t *diff_weights_layer_ desc, const mkldnn_memory_desc_t *diff_weights_iter_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_layer_ desc, const mkldnn_memory_desc_t *diff_dst_iter_ desc, unsigned flags, float alpha, float beta)
        {    return static_cast<Nmkldnnstatust>(mkldnn_vanilla_rnn_backward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_alg_kind_t>(activation), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, flags, alpha, beta)); }
        
        static Nmkldnn_status_t _lstm_forward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *src_iter_c_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, const mkldnn_memory_desc_t *dst_iter_c_ desc, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_lstm_forward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, desc, desc, flags)); }
        
        static Nmkldnn_status_t _lstm_backward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *src_iter_c_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, const mkldnn_memory_desc_t *dst_iter_c_ desc, const mkldnn_memory_desc_t *diff_src_layer_ desc, const mkldnn_memory_desc_t *diff_src_iter_ desc, const mkldnn_memory_desc_t *diff_src_iter_c_ desc, const mkldnn_memory_desc_t *diff_weights_layer_ desc, const mkldnn_memory_desc_t *diff_weights_iter_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_layer_ desc, const mkldnn_memory_desc_t *diff_dst_iter_ desc, const mkldnn_memory_desc_t *diff_dst_iter_c_ desc, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_lstm_backward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, flags)); }
        
        static Nmkldnn_status_t _gru_forward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_gru_forward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, flags)); }
        
        static Nmkldnn_status_t _gru_backward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, const mkldnn_memory_desc_t *diff_src_layer_ desc, const mkldnn_memory_desc_t *diff_src_iter_ desc, const mkldnn_memory_desc_t *diff_weights_layer_ desc, const mkldnn_memory_desc_t *diff_weights_iter_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_layer_ desc, const mkldnn_memory_desc_t *diff_dst_iter_ desc, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_gru_backward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, flags)); }
        
        static Nmkldnn_status_t _lbr_gru_forward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_lbr_gru_forward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, flags)); }
        
        static Nmkldnn_status_t _lbr_gru_backward_desc_init(Nmkldnn_rnn_desc_t *rnn_ desc, Nmkldnn_prop_kind_t prop_ kind, Nmkldnn_rnn_direction_t direction, const mkldnn_memory_desc_t *src_layer_ desc, const mkldnn_memory_desc_t *src_iter_ desc, const mkldnn_memory_desc_t *weights_layer_ desc, const mkldnn_memory_desc_t *weights_iter_ desc, const mkldnn_memory_desc_t *bias_ desc, const mkldnn_memory_desc_t *dst_layer_ desc, const mkldnn_memory_desc_t *dst_iter_ desc, const mkldnn_memory_desc_t *diff_src_layer_ desc, const mkldnn_memory_desc_t *diff_src_iter_ desc, const mkldnn_memory_desc_t *diff_weights_layer_ desc, const mkldnn_memory_desc_t *diff_weights_iter_ desc, const mkldnn_memory_desc_t *diff_bias_ desc, const mkldnn_memory_desc_t *diff_dst_layer_ desc, const mkldnn_memory_desc_t *diff_dst_iter_ desc, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_lbr_gru_backward_desc_init(reinterpret_cast<mkldnn_rnn_desc_t*>(desc), static_cast<mkldnn_prop_kind_t>(kind), static_cast<mkldnn_rnn_direction_t>(direction), desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, desc, flags)); }
        
        static size_t _engine_get_count(Nmkldnn_engine_kind_t kind)
        {    return mkldnn_engine_get_count(static_cast<mkldnn_engine_kind_t>(kind)); }
        
        static Nmkldnn_status_t _engine_create(mkldnn_engine_t * engine, Nmkldnn_engine_kind_t kind, size_t index)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_create(engine, static_cast<mkldnn_engine_kind_t>(kind), index)); }
        
        static Nmkldnn_status_t _engine_create_ocl(mkldnn_engine_t * engine, Nmkldnn_engine_kind_t kind, cl_device_id device, cl_context context)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_create_ocl(engine, static_cast<mkldnn_engine_kind_t>(kind), device, context)); }
        
        static Nmkldnn_status_t _engine_get_kind(mkldnn_engine_t engine, Nmkldnn_engine_kind_t * kind)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_get_kind(engine, reinterpret_cast<mkldnn_engine_kind_t*>(kind))); }
        
        static Nmkldnn_status_t _engine_get_ocl_context(mkldnn_engine_t engine, cl_context * context)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_get_ocl_context(engine, context)); }
        
        static Nmkldnn_status_t _engine_get_ocl_device(mkldnn_engine_t engine, cl_device_id * device)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_get_ocl_device(engine, device)); }
        
        static Nmkldnn_status_t _engine_get_kind(mkldnn_engine_t engine, Nmkldnn_engine_kind_t * kind)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_get_kind(engine, reinterpret_cast<mkldnn_engine_kind_t*>(kind))); }
        
        static Nmkldnn_status_t _engine_destroy(mkldnn_engine_t engine)
        {    return static_cast<Nmkldnnstatust>(mkldnn_engine_destroy(engine)); }
        
        static Nmkldnn_status_t _stream_create(mkldnn_stream_t * stream, mkldnn_engine_t engine, unsigned flags)
        {    return static_cast<Nmkldnnstatust>(mkldnn_stream_create(stream, engine, flags)); }
        
        static Nmkldnn_status_t _stream_create_ocl(mkldnn_stream_t * stream, mkldnn_engine_t engine, cl_command_queue queue)
        {    return static_cast<Nmkldnnstatust>(mkldnn_stream_create_ocl(stream, engine, queue)); }
        
        static Nmkldnn_status_t _stream_get_ocl_command_queue(mkldnn_stream_t stream, cl_command_queue * queue)
        {    return static_cast<Nmkldnnstatust>(mkldnn_stream_get_ocl_command_queue(stream, queue)); }
        
        static Nmkldnn_status_t _stream_wait(mkldnn_stream_t stream)
        {    return static_cast<Nmkldnnstatust>(mkldnn_stream_wait(stream)); }
        
        static Nmkldnn_status_t _stream_destroy(mkldnn_stream_t stream)
        {    return static_cast<Nmkldnnstatust>(mkldnn_stream_destroy(stream)); }
        
        static Nmkldnn_status_t _set_verbose(int level)
        {    return static_cast<Nmkldnnstatust>(mkldnn_set_verbose(level)); }
        
        static Nmkldnn_status_t _set_jit_dump(int enable)
        {    return static_cast<Nmkldnnstatust>(mkldnn_set_jit_dump(enable)); }
        
        static Nmkldnn_version_t *mkldnn_version()
        {    return static_cast<Nmkldnnversiont>(*mkldnn_version()); }
        
        static Nmkldnn_status_t _sgemm(char transa, char transb, mkldnn_dim_t M, mkldnn_dim_t N, mkldnn_dim_t K, float alpha, const float * A, mkldnn_dim_t lda, const float * B, mkldnn_dim_t ldb, float beta, float * C, mkldnn_dim_t ldc)
        {    return static_cast<Nmkldnnstatust>(mkldnn_sgemm(transa, transb, M, N, K, alpha, A, lda, B, ldb, beta, C, ldc)); }
        
        static Nmkldnn_status_t _gemm_u8s8s32(char transa, char transb, char offsetc, mkldnn_dim_t M, mkldnn_dim_t N, mkldnn_dim_t K, float alpha, const uint8_t * A, mkldnn_dim_t lda, uint8_t ao, const int8_t * B, mkldnn_dim_t ldb, int8_t bo, float beta, int32_t * C, mkldnn_dim_t ldc, const int32_t * co)
        {    return static_cast<Nmkldnnstatust>(mkldnn_gemm_u8s8s32(transa, transb, offsetc, M, N, K, alpha, A, lda, ao, B, ldb, bo, beta, C, ldc, co)); }
        
        static Nmkldnn_status_t _gemm_s8s8s32(char transa, char transb, char offsetc, mkldnn_dim_t M, mkldnn_dim_t N, mkldnn_dim_t K, float alpha, const int8_t * A, mkldnn_dim_t lda, int8_t ao, const int8_t * B, mkldnn_dim_t ldb, int8_t bo, float beta, int32_t * C, mkldnn_dim_t ldc, const int32_t * co)
        {    return static_cast<Nmkldnnstatust>(mkldnn_gemm_s8s8s32(transa, transb, offsetc, M, N, K, alpha, A, lda, ao, B, ldb, bo, beta, C, ldc, co)); }
        

	};
} }